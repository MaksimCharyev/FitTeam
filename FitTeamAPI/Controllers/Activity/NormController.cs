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
        [HttpGet]
        public async Task<ActionResult<List<Norm>>> GetAllNorms()
        {
            var norms = await _databaseContext.norms.ToListAsync();
            return Ok(norms);
        }
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Norm>> GetNormByID([FromRoute] int id)
        {
            var norm = await _databaseContext.norms.FirstOrDefaultAsync(x => x.NormID == id);
            return Ok(norm);
        }
        [HttpPost]
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
        [HttpPatch]
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
        [HttpDelete]
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
    [Route("api/[controller]")]
    [ApiController]
    public class Worker_does_normController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public Worker_does_normController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorker_does_norm([FromBody] CreateWorker_does_normDTO worker_does_normDTO)
        {
            var worker_does_norm = new Worker_does_norm()
            {
                Worker = worker_does_normDTO.Worker,
                WorkerID = worker_does_normDTO.WorkerID,
                Norm = worker_does_normDTO.Norm,
                NormID = worker_does_normDTO.NormID,
                NormTime = worker_does_normDTO.NormTime,
                Mark = worker_does_normDTO.Mark,
                Host = worker_does_normDTO.Host,
                HostID = worker_does_normDTO.HostID,
            };
            await _databaseContext.AddAsync(worker_does_norm);
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker_does_norm has been added");
        }
        [HttpGet]
        [Route("Workerid")]
        public async Task<ActionResult<List<Worker_does_norm>>> GetNormsforWorkerByID([FromRoute] int Workerid)
        {
            var workers_norms = await _databaseContext.workers_does_norms.Where(x => x.WorkerID == Workerid).ToListAsync();
            return Ok(workers_norms);
        }
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateNorm([FromRoute] int id, [FromBody] CreateWorker_does_normDTO worker_does_normDTO)
        {
            var worker_does_norm = await _databaseContext.workers_does_norms.FirstOrDefaultAsync(x => x.WNID == id);
            if (worker_does_norm == null)
            {
                return NotFound("Worker_does_norms not found!");
            }
            worker_does_norm.Worker = worker_does_normDTO.Worker;
            worker_does_norm.WorkerID = worker_does_normDTO.WorkerID;
            worker_does_norm.Norm = worker_does_normDTO.Norm;
            worker_does_norm.NormID = worker_does_normDTO.NormID;
            worker_does_norm.NormTime = worker_does_normDTO.NormTime;
            worker_does_norm.Mark = worker_does_normDTO.Mark;
            worker_does_norm.Host = worker_does_normDTO.Host;
            worker_does_norm.HostID = worker_does_normDTO.HostID;
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker_does_norms has been updated");
        }
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWorker_does_norm([FromRoute] int id)
        {
            var worker_does_norm = await _databaseContext.workers_does_norms.FirstOrDefaultAsync(x => x.WNID == id);
            if (worker_does_norm == null)
            {
                return NotFound("Worker_does_norms not found!");
            }
            _databaseContext.workers_does_norms.Remove(worker_does_norm);
            return Ok("Worker_does_norms has been deleted");
        }
    }
}