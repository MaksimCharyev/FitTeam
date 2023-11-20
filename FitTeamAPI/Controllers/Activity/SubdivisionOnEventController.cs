using FitTeamAPI.Context;
using FitTeamAPI.DTO.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.Models.Subdivision;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubdivisionOnEventController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public SubdivisionOnEventController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateWorkerOnEvent([FromBody] SubdivisionOnEventDTO dto)
        {
            var Subdivision_on_event = new Subdivision_on_event()
            {
                SEID = dto.SEID,
                Subdivision = dto.Subdivision,
                SubdivisionID = dto.SubdivisionID,
                Event = dto.Event,
                EventID = dto.EventID,
            };
            await _databaseContext.AddAsync(Subdivision_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Subdivision Added To Event");
        }
        // Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWorkerOnEvent([FromRoute] int id)
        {
            var Subdivision_on_event = await _databaseContext.subdivisions_on_events.FirstOrDefaultAsync(x => x.SEID == id);

            if (Subdivision_on_event == null)
            {
                return NotFound("Worker Is Not On That Event");
            }
            _databaseContext.subdivisions_on_events.Remove(Subdivision_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Subdivision has been removed from event");
        }
    }
}
