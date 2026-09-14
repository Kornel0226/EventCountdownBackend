using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventCountdownBackend.Models;
using EventCountdownBackend.Data;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _context;
    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Event
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
    {
        return await _context.Events.ToListAsync();
    }

    // GET: api/Event/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(string id)
    {
        var eventEntity = await _context.Events.FindAsync(id);

        if (eventEntity == null)
        {
            return NotFound();
        }

        return eventEntity;
    }

  
    // POST: api/Event
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Event>> PostEvent(Event eventEntity)
    {
        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEvent", new { id = eventEntity.Id }, eventEntity);
    }

    // DELETE: api/Event/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(string? id)
    {
        var eventEntity = await _context.Events.FindAsync(id);
        if (eventEntity == null)
        {
            return NotFound();
        }

        _context.Events.Remove(eventEntity);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventExists(string? id)
    {
        return _context.Events.Any(e => e.Id == id);
    }
}
