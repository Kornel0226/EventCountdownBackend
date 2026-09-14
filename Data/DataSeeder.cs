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
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "New Year's Eve 2027",
                Description = "Countdown celebration to welcome the new year.",
                ImageUrl = "https://images.unsplash.com/photo-1514525253161-7a46d19cd819",
                EventDateTime = new DateTime(2026, 12, 31, 23, 59, 59, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Product Launch Keynote",
                Description = "Annual flagship product release and live stream demo.",
                ImageUrl = "https://images.unsplash.com/photo-1505373877841-8d25f7d46678",
                EventDateTime = DateTime.UtcNow.AddMonths(1)
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Global Hackathon",
                Description = "48-hour virtual hackathon with teams around the world.",
                ImageUrl = "https://images.unsplash.com/photo-1515187029135-18ee286d815b",
                EventDateTime = DateTime.UtcNow.AddDays(14)
            }
        };

            await context.Events.AddRangeAsync(sampleEvents);
            await context.SaveChangesAsync(); // Your SaveChangesAsync will automatically assign CreatedAt
        }
    }
}

