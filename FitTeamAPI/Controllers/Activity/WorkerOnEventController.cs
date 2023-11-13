using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.Models.Worker;
using FitTeamAPI.Context;
using FitTeamAPI.DTO.Events;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerOnEventController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public WorkerOnEventController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateWorkerOnEvent([FromBody] WorkerOnEventDTO dto)
        {
            var Worker_on_event = new Worker_on_event()
            {
                WEID = dto.WEID,
                Worker = dto.Worker,
                WorkerID = dto.WorkerID,
                Event = dto.Event,
                EventID = dto.EventID,
            };
            await _databaseContext.AddAsync(Worker_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker Added To Event");
        }
        // Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWorkerOnEvent([FromRoute] int id)
        {
            var Worker_on_event = await _databaseContext.workers_on_events.FirstOrDefaultAsync(x => x.WEID == id);

            if (Worker_on_event == null)
            {
                return NotFound("Worker Is Not On That Event");
            }
            _databaseContext.workers_on_events.Remove(Worker_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker has been removed from event");
        }
    }
}
