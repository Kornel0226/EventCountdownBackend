using EventCountdownBackend.Common.Results;
using EventCountdownBackend.DTOs;
using EventCountdownBackend.Models;
using System.Collections;

namespace EventCountdownBackend.Interfaces
{
    public interface IEventRepository
    {
        Task<ICollection<Event>> GetAllAsync(CancellationToken ct = default);
        Task<Event?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<Event> CreateAsync(CreateEventRequestDTO createEventDTO, CancellationToken ct = default);

        // Will be UpdateEventDTO
        Task<MutationResult<Event>> UpdateAsync(string id, string? userId, UpdateEventRequestDTO eventUpdateRequest, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, string? userId, CancellationToken ct = default);
        Task<bool> ExistsAsync(string id, CancellationToken ct = default);
    }
}
