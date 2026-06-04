using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        public async Task<bool> ConnectEventsAsync(string project, Action<string> onMessage, CancellationToken cancellationToken = default)
        {
            if (IsConnected && currentProject == project) return true;

            currentProject = project;
            currentOnMessage = onMessage;
            reconnectAttempts = 0;

            return await AttemptConnectionAsync(cancellationToken);
        }

        private async Task ReceiveLoopAsync()
        {
            try
            {
                var socket = eventSocket;
                var cts = eventCts;
                var buffer = new byte[8192];

                if (socket is null || cts is null) return;

                while (socket.State == WebSocketState.Open && !cts.IsCancellationRequested)
                {
                    using var ms = new MemoryStream();
                    WebSocketReceiveResult result;

                    try
                    {
                        do
                        {
                            result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

                            if (result.MessageType == WebSocketMessageType.Close)
                            {
                                await TriggerReconnectAsync();
                                return;
                            }

                            ms.Write(buffer, 0, result.Count);
                        } while (!result.EndOfMessage);

                        var msg = Encoding.UTF8.GetString(ms.ToArray());
                        try
                        {
                            currentOnMessage?.Invoke(msg);
                            ProcessRealtimeMessage(msg);
                        }
                        catch { }
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (WebSocketException)
                    {
                        await TriggerReconnectAsync();
                        return;
                    }
                }
            }
            catch { }
            finally
            {
                if (IsConnected)
                {
                    await TriggerReconnectAsync();
                }
            }
        }

        private void ProcessRealtimeMessage(string jsonMessage)
        {
            try
            {
                var msg = JsonSerializer.Deserialize<RealtimeMessage>(jsonMessage);
                if (msg == null) return;

                switch (msg.Type)
                {
                    case "annotation-created":
                        OnAnnotationCreated?.Invoke(this, new AnnotationCreatedEventArgs
                        {
                            Project = msg.Project,
                            Image = msg.Image,
                            User = msg.User
                        });
                        break;

                    case "image-locked":
                        OnImageLocked?.Invoke(this, new ImageLockedEventArgs
                        {
                            Project = msg.Project,
                            Image = msg.Image,
                            User = msg.User
                        });
                        break;

                    case "image-unlocked":
                        OnImageUnlocked?.Invoke(this, new ImageUnlockedEventArgs
                        {
                            Project = msg.Project,
                            Image = msg.Image,
                            User = msg.User
                        });
                        break;

                    case "class-created":
                        OnClassCreated?.Invoke(this, new ClassCreatedEventArgs
                        {
                            Project = msg.Project,
                            ClassName = msg.Detail
                        });
                        break;

                    case "class-deleted":
                        OnClassDeleted?.Invoke(this, new ClassDeletedEventArgs
                        {
                            Project = msg.Project,
                            ClassName = msg.Detail
                        });
                        break;
                }
            }
            catch { }
        }

    }
}
