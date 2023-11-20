using FitTeamAPI.DTO.Events;
using FitTeamAPI.Context;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.Models.Event;
using FitTeamAPI.Models.Worker;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public EventsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO dto)
        {
            var Event = new Event()
            {
                EventID = dto.EventID,
                EventName = dto.EventName,
                EventDescription = dto.EventDescription,
                EventTime = dto.EventTime,
                Host = dto.Host,
            };
            await _databaseContext.AddAsync(Event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Event has been added");
        }
        //Read
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Event>> GetEventByID([FromRoute] int id)
        {
            var Event = await _databaseContext.events.FirstOrDefaultAsync(x => x.EventID == id);

            if (Event == null)
            {
                return NotFound("Event Not Found");
            }

            return Ok(Event);
        }
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEvents()
        {
            var Events = await _databaseContext.events.ToListAsync();
            return Ok(Events);
        }
        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] CreateEventDTO eventDTO)
        {
            var Event = await _databaseContext.events.FirstOrDefaultAsync(x => x.EventID == id);

            if (Event == null)
            {
                return NotFound("Event Not Found");
            }
            Event.EventName = eventDTO.EventName;
            Event.EventDescription = eventDTO.EventDescription;
            Event.EventTime = eventDTO.EventTime;
            await _databaseContext.SaveChangesAsync();
            return Ok("Event has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var Event = await _databaseContext.events.FirstOrDefaultAsync(x => x.EventID == id);

            if (Event == null)
            {
                return NotFound("Event Not Found");
            }

            _databaseContext.events.Remove(Event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Event has been deleted");
        }
    }
}
