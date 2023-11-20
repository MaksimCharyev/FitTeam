using FitTeamAPI.Context;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.Models.Worker;
using FitTeamAPI.Models.Norm;
using Microsoft.EntityFrameworkCore;
using FitTeamAPI.DTO.Activity;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public NormController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpGet]//получение всех нормативов из БД
        public async Task<ActionResult<List<Norm>>> GetAllNorms()
        {
            var norms = await _databaseContext.norms.ToListAsync();
            return Ok(norms);
        }
        [HttpGet]//получение норматива по его id
        [Route("id")]
        public async Task<ActionResult<Norm>> GetNormByID([FromRoute] int id)
        {
            var norm = await _databaseContext.norms.FirstOrDefaultAsync(x => x.NormID == id);
            return Ok(norm);
        }
        [HttpPost]//создание нового норматива
        public async Task<IActionResult> CreateNorm([FromBody] CreateNormDTO normDTO)
        {
            var norm = new Norm()
            {
                NormName = normDTO.NormName,
                NormDescription = normDTO.NormDescription,
            };
            await _databaseContext.AddAsync(norm);
            await _databaseContext.SaveChangesAsync();
            return Ok("Norm has been added");
        }
        [HttpPatch]//изменения полей норматива по id
        [Route("id")]
        public async Task<IActionResult> UpdateNorm([FromRoute] int id, [FromBody] CreateNormDTO normDTO)
        {
            var norm = await _databaseContext.norms.FirstOrDefaultAsync(x => x.NormID == id);
            if (norm == null)
            {
                return NotFound("Norm not found!");
            }
            norm.NormName = normDTO.NormName;
            norm.NormDescription = normDTO.NormDescription;
            await _databaseContext.SaveChangesAsync();
            return Ok("Norm has been updated");
        }
        [HttpDelete]//удаление норматива по id
        [Route("id")]
        public async Task<IActionResult> DeleteNorm([FromRoute] int id)
        {
            var norm = await _databaseContext.norms.FirstOrDefaultAsync(x => x.NormID == id);
            if (norm == null)
            {
                return NotFound("Norm not found!");
            }
            _databaseContext.norms.Remove(norm);
            return Ok("Norm has been deleted");
        }
    }
}