using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;

namespace VisComClient.Connection
{
    public partial class ServerConnection
    {
        private readonly CookieContainer Cookies = new();
        private readonly HttpClientHandler Handler;

        public HttpClient Client = new();
        public string Credentials = "";
        private readonly string UserName;

        // WebSocket event management
        private ClientWebSocket? eventSocket;
        private CancellationTokenSource? eventCts;
        private string? currentProject;
        private Action<string>? currentOnMessage;
        private int reconnectAttempts = 0;
        private const int MaxReconnectAttempts = 10;
        private const int InitialBackoffMs = 1000;

        // State and events
        public bool IsConnected => eventSocket?.State == WebSocketState.Open;
        public bool IsConnecting { get; private set; }
        public string CurrentProject => currentProject ?? "";

        public event EventHandler<EventArgs>? EventsConnected;
        public event EventHandler<EventArgs>? EventsDisconnected;
        public event EventHandler<string>? EventsError;

        // Typed events for each notification type
        public event EventHandler<AnnotationCreatedEventArgs>? OnAnnotationCreated;
        public event EventHandler<ImageLockedEventArgs>? OnImageLocked;
        public event EventHandler<ImageUnlockedEventArgs>? OnImageUnlocked;
        public event EventHandler<ClassCreatedEventArgs>? OnClassCreated;
        public event EventHandler<ClassDeletedEventArgs>? OnClassDeleted;

        public ServerConnection(string URI, string User) 
        {
            UserName = User;
            Handler = new HttpClientHandler
            {
                CookieContainer = Cookies,
                UseCookies = true
            };

            Client = new HttpClient(Handler) { BaseAddress = new Uri(URI) };
            Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{User}:{User}"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Credentials);
        }
    }
}
