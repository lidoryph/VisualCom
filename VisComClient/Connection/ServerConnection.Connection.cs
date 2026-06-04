using System.Net.WebSockets;

namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        public async Task<int> PingServer()
        {
            HttpResponseMessage Response = await Client.GetAsync("/");
            int ResponseCode = (int)Response.StatusCode;
            return ResponseCode;
        }

        private async Task<bool> AttemptConnectionAsync(CancellationToken cancellationToken)
        {
            if (IsConnecting) return false;

            IsConnecting = true;

            try
            {
                // Cleanup old socket
                CleanupSocket();

                eventSocket = new ClientWebSocket();
                eventSocket.Options.Cookies = Cookies;

                // Build ws/wss Uri
                var baseUri = Client.BaseAddress ?? throw new InvalidOperationException("BaseAddress not set");
                var ub = new UriBuilder(baseUri);
                ub.Scheme = ub.Scheme == "https" ? "wss" : "ws";
                var basePath = baseUri.AbsolutePath.TrimEnd('/');
                ub.Path = (basePath + "/events/" + currentProject).Replace("//", "/");
                var wsUri = ub.Uri;

                // Attempt connection with timeout
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
                {
                    var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
                    await eventSocket.ConnectAsync(wsUri, linkedCts.Token);
                }

                eventCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                reconnectAttempts = 0;
                IsConnecting = false;

                EventsConnected?.Invoke(this, EventArgs.Empty);

                // Start receive loop
                _ = ReceiveLoopAsync();

                // Start heartbeat
                _ = HeartbeatLoopAsync();

                return true;
            }
            catch (Exception ex)
            {
                IsConnecting = false;
                reconnectAttempts++;
                EventsError?.Invoke(this, $"Conexión fallida (intento {reconnectAttempts}/{MaxReconnectAttempts}): {ex.Message}");

                // Trigger automatic reconnect if under limit
                if (reconnectAttempts < MaxReconnectAttempts)
                {
                    int backoffMs = InitialBackoffMs * (int)Math.Pow(2, reconnectAttempts - 1);
                    backoffMs = Math.Min(backoffMs, 30000); // Cap at 30 seconds
                    _ = Task.Delay(backoffMs, cancellationToken).ContinueWith(_ => AttemptConnectionAsync(cancellationToken));
                }
                else
                {
                    EventsError?.Invoke(this, "Máximo número de reintentos de conexión alcanzado. Se requiere login manual.");
                }

                return false;
            }
        }

        private async Task HeartbeatLoopAsync()
        {
            const int HeartbeatIntervalMs = 30000;
            var socket = eventSocket;
            var cts = eventCts;

            if (socket is null || cts is null) return;

            try
            {
                while (socket.State == WebSocketState.Open && !cts.IsCancellationRequested)
                {
                    await Task.Delay(HeartbeatIntervalMs, cts.Token);

                    if (socket.State == WebSocketState.Open && !cts.IsCancellationRequested)
                    {
                        try
                        {
                            await socket.SendAsync(
                                new ArraySegment<byte>(new byte[1]),
                                WebSocketMessageType.Binary,
                                true,
                                cts.Token);
                        }
                        catch
                        {
                            await TriggerReconnectAsync();
                            return;
                        }
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch { }
        }

        private async Task TriggerReconnectAsync()
        {
            if (currentProject == null) return;

            EventsDisconnected?.Invoke(this, EventArgs.Empty);
            CleanupSocket();

            // Attempt reconnection
            await AttemptConnectionAsync(CancellationToken.None);
        }

        private void CleanupSocket()
        {
            try
            {
                eventCts?.Cancel();
                eventCts?.Dispose();

                if (eventSocket != null)
                {
                    if (eventSocket.State == WebSocketState.Open || eventSocket.State == WebSocketState.CloseSent)
                    {
                        try
                        {
                            eventSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cleanup", CancellationToken.None).Wait(1000);
                        }
                        catch { }
                    }
                    eventSocket.Dispose();
                    eventSocket = null;
                }
            }
            catch { }
        }

    }
}
