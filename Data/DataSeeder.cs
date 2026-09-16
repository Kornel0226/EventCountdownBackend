using EventCountdownBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCountdownBackend.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Events.AnyAsync())
            {
                return;
            }

            var sampleEvents = new List<Event>
            {
                // In-Person Event 1 (Times Square, New York)
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "New Year's Eve 2027",
                    Description = "Countdown celebration to welcome the new year.",
                    ImageUrl = "https://images.unsplash.com/photo-1514525253161-7a46d19cd819",
                    IsOnline = false,
                    FormattedAddress = "Times Square, Manhattan, NY 10036, United States",
                    City = "New York",
                    Country = "United States",
                    Latitude = 40.758896,
                    Longitude = -73.985130,
                    PlaceId = "ChIJmQJIxlVYwokRLdaAnbmqxbA",
                    EventDateTime = new DateTime(2026, 12, 31, 23, 59, 59, DateTimeKind.Utc),
                    CreatedAt = DateTime.UtcNow
                },

                // In-Person Event 2 (Station F, Paris)
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tech Innovation Summit",
                    Description = "Annual flagship product release and live tech showcase.",
                    ImageUrl = "https://images.unsplash.com/photo-1505373877841-8d25f7d46678",
                    IsOnline = false,
                    FormattedAddress = "55 Bd Vincent Auriol, 75013 Paris, France",
                    City = "Paris",
                    Country = "France",
                    Latitude = 48.834458,
                    Longitude = 2.370779,
                    PlaceId = "ChIJG-469bBx5kcRPp6e0oUqXrw",
                    EventDateTime = DateTime.UtcNow.AddMonths(1),
                    CreatedAt = DateTime.UtcNow
                },

                // Online Event (Virtual Hackathon - No physical location required)
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Global Hackathon 2026",
                    Description = "48-hour virtual hackathon with teams competing from around the world.",
                    ImageUrl = "https://images.unsplash.com/photo-1515187029135-18ee286d815b",
                    IsOnline = true,
                    OnlineEventUrl = "https://meet.google.com/abc-defg-hij",
                    // Physical location fields left null:
                    Latitude = null,
                    Longitude = null,
                    FormattedAddress = null,
                    City = null,
                    Country = null,
                    PlaceId = null,
                    EventDateTime = DateTime.UtcNow.AddDays(14),
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Events.AddRangeAsync(sampleEvents);
            await context.SaveChangesAsync();
        }
    }
}