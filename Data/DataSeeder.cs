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
                    City = "New York",
                    Country = "United States",
                    Address = "Times Square, Manhattan",
                    ZipCode = 10036,
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
                    City = "Paris",
                    Country = "France",
                    ZipCode = 75013,
                    Address = "55 Bd Vincent Auriol",
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
                    EventDateTime = DateTime.UtcNow.AddDays(14),
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Events.AddRangeAsync(sampleEvents);
            await context.SaveChangesAsync();
        }
    }
}