using EventCountdownBackend.Common.Results;
using EventCountdownBackend.Data;
using EventCountdownBackend.DTOs;
using EventCountdownBackend.Interfaces;
using EventCountdownBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCountdownBackend.Repository
{
    public class EventRepository(AppDbContext context) : IEventRepository
    {
        public async Task<Event> CreateAsync(CreateEventRequestDTO eventRequest, CancellationToken ct = default)
        {
            // Convert creation DTO to event entity, and create it in db

            var entry = await context.Events.AddAsync(eventRequest.ToEntity(), ct);
            await context.SaveChangesAsync(ct);

            return entry.Entity;
          
        }

        public async Task<bool> DeleteAsync(string id, string? userId, CancellationToken ct = default)
        {
            var rowAffected = await context.Events
                .Where(e => e.Id == id && e.UserId == userId)
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

        public async Task<MutationResult<Event>> UpdateAsync(
            string id,
            string? userId,
            UpdateEventRequestDTO eventUpdateRequest,
            CancellationToken ct = default
            )
        {
            var existingEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == id, ct);

            /*
             * Return MutationResult, so if the request failed, the controller can access the cause (404/403).
             */

            if (existingEvent is null) {
                return new MutationResult<Event>(MutationStatus.NotFound);
            }

            if (existingEvent.Id is not null && existingEvent.UserId != userId)
            {
               return new MutationResult<Event>(MutationStatus.Forbidden);
            }

            eventUpdateRequest.PatchEntity(existingEvent);
            await context.SaveChangesAsync(ct);
            return new MutationResult<Event>(MutationStatus.Success, existingEvent);
        }
    }
}
