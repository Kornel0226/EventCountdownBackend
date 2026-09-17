using EventCountdownBackend.Data;
using EventCountdownBackend.DTOs;
using EventCountdownBackend.Interfaces;
using EventCountdownBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCountdownBackend.Repository
{
    public class EventRepository(AppDbContext context) : IEventRepository
    {
        public Task<Event> CreateAsync(CreateEventRequest createEventDTO, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            var rowAffected = await context.Events
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync(ct);

            return rowAffected > 0;
        }

        public async Task<bool> ExistsAsync(string id, CancellationToken ct = default)
        {
            return await context.Events.AnyAsync<Event>(e => e.Id == id, ct);
        }

        public async Task<ICollection<Event>> GetAllAsync(CancellationToken ct = default)
        {
            return await context.Events.ToListAsync(cancellationToken: ct);
        }

        public async Task<Event?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            return await context.Events.FindAsync([id], cancellationToken: ct);
        }

        public Task<Event?> UpdateAsync(string id, Event eventEntity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
