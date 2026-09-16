using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventCountdownBackend.Models;
using EventCountdownBackend.Data;
using EventCountdownBackend.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventRepository eventRepository) : ControllerBase
{

    // GET: api/Event
    [HttpGet]
    public async Task<ActionResult<ICollection<Event>>> GetEvent()
    {
        // Will have to implement error handling and stuff, its just a fast implementation for basic functionality

        var events = await eventRepository.GetAllAsync();
        return Ok(events);
    }

    // GET: api/Event/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(string id)
    {
        var eventEntity = await eventRepository.GetByIdAsync(id);

        if (eventEntity == null)
        {
            return NotFound();
        }

        return Ok(eventEntity);
    }

  
    // POST: api/Event
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Event>> PostEvent(Event eventEntity)
    {
        throw new NotImplementedException("Creating new events not implemented yet");
    }

    // DELETE: api/Event/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(string? id)
    {
        throw new NotImplementedException("Deleting event not implemented yet");
    }

    private async Task<ActionResult<bool>> EventExists(string id)
    {
        var result = await eventRepository.ExistsAsync(id);
        return Ok(result);
    }
}
