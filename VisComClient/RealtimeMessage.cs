using System.Text.Json.Serialization;

namespace VisComClient
{
    public class RealtimeMessage
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("project")]
        public string? Project { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("user")]
        public string? User { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }
    }

    // Typed event args for each notification type
    public class AnnotationCreatedEventArgs : EventArgs
    {
        public string? Project { get; set; }
        public string? Image { get; set; }
        public string? User { get; set; }
    }

    public class ImageLockedEventArgs : EventArgs
    {
        public string? Project { get; set; }
        public string? Image { get; set; }
        public string? User { get; set; }
    }

    public class ImageUnlockedEventArgs : EventArgs
    {
        public string? Project { get; set; }
        public string? Image { get; set; }
        public string? User { get; set; }
    }

    public class ClassCreatedEventArgs : EventArgs
    {
        public string? Project { get; set; }
        public string? ClassName { get; set; }
    }

    public class ClassDeletedEventArgs : EventArgs
    {
        public string? Project { get; set; }
        public string? ClassName { get; set; }
    }
}
