using FitTeamAPI.Context;
using FitTeamAPI.DTO.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleOnEventController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public RoleOnEventController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateWorkerOnEvent([FromBody] RoleOnEventDTO dto)
        {
            var Role_on_event = new Role_on_event()
            {
                REID = dto.REID,
                Role = dto.Role,
                RoleID = dto.RoleID,
                Event = dto.Event,
                EventID = dto.EventID,
            };
            await _databaseContext.AddAsync(Role_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Role Added To Event");
        }
        // Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWorkerOnEvent([FromRoute] int id)
        {
            var Role_on_event = await _databaseContext.roles_on_events.FirstOrDefaultAsync(x => x.REID == id);

            if (Role_on_event == null)
            {
                return NotFound("Worker Is Not On That Event");
            }
            _databaseContext.roles_on_events.Remove(Role_on_event);
            await _databaseContext.SaveChangesAsync();
            return Ok("Role has been removed from event");
        }
    }
}
