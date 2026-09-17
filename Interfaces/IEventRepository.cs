using EventCountdownBackend.DTOs;
using EventCountdownBackend.Models;
using System.Collections;

namespace EventCountdownBackend.Interfaces
{
    public interface IEventRepository
    {
        Task<ICollection<Event>> GetAllAsync(CancellationToken ct = default);
        Task<Event?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<Event> CreateAsync(CreateEventRequest createEventDTO, CancellationToken ct = default);

        // Will be UpdateEventDTO
        Task<Event?> UpdateAsync(string id, Event eventEntity, CancellationToken ct = default);

        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<bool> ExistsAsync(string id, CancellationToken ct = default);
    }
}
