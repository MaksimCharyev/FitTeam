using FitTeamAPI.Context;
using Microsoft.AspNetCore.Mvc;
using FitTeamAPI.DTO.Administration;
using FitTeamAPI.Models.Worker;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitTeamAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public WorkerController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerDTO workerDTO)
        {
            var worker = new Worker()
            {
                FirstName = workerDTO.FirstName,
                LastName = workerDTO.LastName,
                MiddleName = workerDTO.MiddleName,
                Email = workerDTO.Email,
                Password = workerDTO.Password,
                //Всем привет! Сегодня у нас обзор на книгу Гёте "Фауст". Это поэма, изначально написанная на немецком, но благодаря искусному переводчику Борису Пастернаку, мы имеем возможность наслаждаться данной книгой на русском языке в прекрасной адаптации. Некоторые критики уверены, что в переводе Пастернака произведения приобретают выигрывающее оригинал звучание и ритмитность. И я не могу не согласиться с ними
            };
            await _databaseContext.AddAsync(worker);
            await _databaseContext.SaveChangesAsync();
            return Ok("User has been added");
        }
        //Read
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Worker>>GetWorkerByID([FromRoute] int id)
        {
            var worker = await _databaseContext.workers.FirstOrDefaultAsync(x=> x.UUID == id);
            if(worker == null)
            {
                return NotFound("Worker not found!");
            }
            return Ok(worker);
        }
        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetWorkers()
        {
            var workers = await _databaseContext.workers.ToListAsync();
            return Ok(workers);
        }
        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult>UpdateWorker([FromRoute] int id, [FromBody] CreateWorkerDTO workerDTO)
        {
            var worker = await _databaseContext.workers.FirstOrDefaultAsync(x => x.UUID == id);
            if(worker == null)
            {
                return NotFound("User not found!");
            }
            worker.LastName = workerDTO.LastName;
            worker.FirstName = workerDTO.FirstName;
            worker.Email = workerDTO.Email;
            worker.Password = workerDTO.Password;
            await _databaseContext.SaveChangesAsync();
            return Ok("User has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteWorker([FromRoute] int id)
        {
            var worker = await _databaseContext.workers.FirstOrDefaultAsync(x => x.UUID==id);
            if(worker == null)
            {
                return NotFound("User not found!");
            }
            _databaseContext.workers.Remove(worker);
            return Ok("User has been deleted");
        }
    }
}
