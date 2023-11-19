using FitTeamAPI.Context;
using FitTeamAPI.DTO.Activity;
using FitTeamAPI.Models.SalePlan;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePlanController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public SalePlanController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] SalePlanDTO dto)
        {
            var SalePlan = new SalePlan()
            {
                SalePlanID = dto.SalePlanID,
                SalePlanName = dto.SalePlanName,
                URL = dto.URL,
            };
            await _databaseContext.AddAsync(SalePlan);
            await _databaseContext.SaveChangesAsync();
            return Ok("SalePlan has been added");
        }
        //Read
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<SalePlan>> GetSalePlanByID([FromRoute] int id)
        {
            var SalePlan = await _databaseContext.salePlans.FirstOrDefaultAsync(x => x.SalePlanID == id);

            if (SalePlan == null)
            {
                return NotFound("SalePlan Not Found");
            }

            return Ok(SalePlan);
        }
        [HttpGet]
        public async Task<ActionResult<List<SalePlan>>> GetSalePlans()
        {
            var SalePlans = await _databaseContext.salePlans.ToListAsync();
            return Ok(SalePlans);
        }
        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateSalePlan([FromRoute] int id, [FromBody] SalePlanDTO dto)
        {
            var SalePlan = await _databaseContext.salePlans.FirstOrDefaultAsync(x => x.SalePlanID == id);

            if (SalePlan == null)
            {
                return NotFound("SalePlan Not Found");
            }
            SalePlan.SalePlanName = dto.SalePlanName;
            SalePlan.SalePlanName = dto.SalePlanName;
            SalePlan.URL = dto.URL;
            await _databaseContext.SaveChangesAsync();
            return Ok("SalePlan has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteSalePlan([FromRoute] int id)
        {
            var SalePlan = await _databaseContext.salePlans.FirstOrDefaultAsync(x => x.SalePlanID == id);

            if (SalePlan == null)
            {
                return NotFound("SalePlan Not Found");
            }

            _databaseContext.salePlans.Remove(SalePlan);
            await _databaseContext.SaveChangesAsync();
            return Ok("SalePlan has been deleted");
        }
    }
}
