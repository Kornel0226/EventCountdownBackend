using EventCountdownBackend.Data;
using EventCountdownBackend.Interfaces;
using EventCountdownBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCountdownBackend.Repository
{
    public class EventRepository(AppDbContext context) : IEventRepository
    {
        public Task<Event> CreateAsync(Event eventEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string id)
        {
            return context.Events.AnyAsync<Event>(e => e.Id == id);
        }

        public async Task<ICollection<Event>> GetAllAsync()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(string id)
        {
            return await context.Events.FindAsync(id);
        }

        public Task<Event?> UpdateAsync(int id, Event eventEntity)
        {
            throw new NotImplementedException();
        }
    }
}
