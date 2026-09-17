using EventCountdownBackend.Models;

namespace EventCountdownBackend.DTOs
{
    public class CreateEventRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public bool IsOnline { get; set; } = false;
        public string? OnlineEventUrl { get; set; }
        public DateTime EventDateTime { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
    }

    public static class EventExtensions
    {
        // Extension method to map CreateEventRequest to Event
        public static Event ToEntity(this CreateEventRequest request)
        {
            return new Event
            {
                // Generate a unique ID if your entity uses string IDs
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                IsOnline = request.IsOnline,
                OnlineEventUrl = request.OnlineEventUrl,
                EventDateTime = request.EventDateTime,
                Country = request.Country,
                City = request.City,
                Address = request.Address,
            };
        }
    }
}