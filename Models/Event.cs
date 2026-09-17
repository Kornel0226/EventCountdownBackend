namespace EventCountdownBackend.Models
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        // Meeting / Stream link if the event is online
        public bool IsOnline { get; set; } = false;
        public string? OnlineEventUrl { get; set; }

        public DateTime EventDateTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Physical location fields (used when !IsOnline)
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? ZipCode { get; set; }
    }

}
