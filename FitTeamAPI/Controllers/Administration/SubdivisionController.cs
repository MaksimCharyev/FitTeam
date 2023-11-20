using FitTeamAPI.Context;
using FitTeamAPI.DTO.Administration;
using FitTeamAPI.Models.Subdivision;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubdivisionController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public SubdivisionController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> CreateSubdivision([FromBody] CreateSubdivDTO SubdivDTO)
        {
            var Subdiv = new Subdivision()
            {
                SubdivisionName = SubdivDTO.Name,
                SubdivisionDescription = SubdivDTO.Description,
                
            };
            await _databaseContext.AddAsync(Subdiv);
            await _databaseContext.SaveChangesAsync();
            return Ok("Subdiv has been added");
        }
        //Read
        [HttpGet]
        public async Task<ActionResult<List<Subdivision>>> GetAllSubdivisions()
        {
            var Subdivs = await _databaseContext.subdivisions.ToListAsync();
            return Ok(Subdivs);
        }
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Subdivision>> GetSubdivisionByID([FromRoute] int id)
        {
            var Subdiv = await _databaseContext.subdivisions.FirstOrDefaultAsync(x => x.SubdivisionID == id);
            if(Subdiv == null)
            {
                return NotFound("Subdivision not found!");
            }
            return Ok(Subdiv);
        }

        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateSubdivision([FromRoute] int id, [FromBody] CreateSubdivDTO SubdivDTO)
        {
            var subdiv = await _databaseContext.subdivisions.FirstOrDefaultAsync(x => x.SubdivisionID == id);
            if (subdiv == null)
            {
                return NotFound("Subdivision not found!");
            }
            subdiv.SubdivisionName = SubdivDTO.Name;
            subdiv.SubdivisionDescription = SubdivDTO.Description;
            await _databaseContext.SaveChangesAsync();
            return Ok("Subdiv has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteSubdivision([FromRoute] int id)
        {
            var subdiv = await _databaseContext.subdivisions.FirstOrDefaultAsync(x => x.SubdivisionID == id);
            if (subdiv == null)
            {
                return NotFound("Subdivision not found!");
            }
            _databaseContext.subdivisions.Remove(subdiv);
            return Ok("Subdivision has been deleted");
        }
    }
}
