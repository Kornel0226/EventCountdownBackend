using Microsoft.AspNetCore.Mvc;
using EventCountdownBackend.Models;
using EventCountdownBackend.Interfaces;


[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventRepository eventRepository) : ControllerBase
{

    // GET: api/Event
    [HttpGet]
    public async Task<ActionResult<ICollection<Event>>> GetEvent()
    {
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
    public async Task<IActionResult> DeleteEvent(string id, CancellationToken ct = default)
    {
        var deleted = await eventRepository.DeleteAsync(id, ct);

        if (deleted == false)
        {
            throw new KeyNotFoundException($"Event with ID {id} was not found.");
        }

        return NoContent();
    }

    private async Task<ActionResult<bool>> EventExists(string id)
    {
        var result = await eventRepository.ExistsAsync(id);
        return Ok(result);
    }
}
