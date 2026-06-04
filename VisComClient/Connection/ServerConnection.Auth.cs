using System.Net.WebSockets;

namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        public async Task<bool> LoginAsync()
        {
            HttpResponseMessage Request;
            try { Request = await Client.GetAsync($"/login/{UserName}"); }
            catch { return false; }

            if ((int)Request.StatusCode == 200)
                return true;
            else return false;
        }

        public async Task<int> LogoutAsync()
        {
            HttpResponseMessage Request = await Client.GetAsync("/logout");
            return (int)Request.StatusCode;
        }

        public async Task DisconnectEventsAsync()
        {
            currentProject = null;
            currentOnMessage = null;
            reconnectAttempts = 0;
            IsConnecting = false;
            
            if (eventSocket == null)
                return;

            try { if (IsConnected) await eventSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnect", CancellationToken.None); }
            catch { }

            CleanupSocket();
            EventsDisconnected?.Invoke(this, EventArgs.Empty);
        }

    }
}
