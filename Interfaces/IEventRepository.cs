using EventCountdownBackend.Models;
using System.Collections;

namespace EventCountdownBackend.Interfaces
{
    public interface IEventRepository
    {
        Task<ICollection<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(string id);
        Task<Event> CreateAsync(Event eventEntity);
        Task<Event?> UpdateAsync(int id, Event eventEntity);
        Task<Event?> DeleteAsync(int id);
        Task<bool> ExistsAsync(string id);
    }
}
