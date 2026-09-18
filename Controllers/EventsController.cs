using Microsoft.AspNetCore.Mvc;
using EventCountdownBackend.Models;
using EventCountdownBackend.Interfaces;
using EventCountdownBackend.DTOs;
using EventCountdownBackend.Common.Results;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;


[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventRepository eventRepository) : ControllerBase
{


    // UserId is nullable for now beacuse it not exist yet, but it will later.


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
    public async Task<ActionResult<Event>> PostEvent(CreateEventRequestDTO eventRequest, CancellationToken ct)
    {
        var createdEvent = await eventRepository.CreateAsync(eventRequest, ct);

        return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Event>> PatchEvent(string id, UpdateEventRequestDTO updateEventRequest, CancellationToken ct)
    {
        var updatedEvent = await eventRepository.UpdateAsync(id, null, updateEventRequest, ct);

        return updatedEvent.Status switch
        {
            MutationStatus.Success => Ok(updatedEvent.Data),
            MutationStatus.NotFound => NotFound(),
            MutationStatus.Forbidden => Forbid(),
            _ => StatusCode(500)
        };
        
    }

    // DELETE: api/Event/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(string id, CancellationToken ct = default)
    {
        var deleted = await eventRepository.DeleteAsync(id, string.Empty, ct);

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
