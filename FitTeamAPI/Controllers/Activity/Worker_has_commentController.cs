using FitTeamAPI.Context;
using FitTeamAPI.DTO.Activity;
using FitTeamAPI.Models.Comment;
using FitTeamAPI.Models.Worker;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class Worker_has_commentController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public Worker_has_commentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpPost]//создание нового экземпляра
        public async Task<IActionResult> CreateWorker_has_comment([FromBody] CreateWorker_has_commentDTO worker_has_commentDTO)
        {
            var worker_has_comment = new Worker_has_comment()
            {
                To = worker_has_commentDTO.To,
                ToID = worker_has_commentDTO.ToID,
                Comment = worker_has_commentDTO.Comment,
                CommentID = worker_has_commentDTO.CommentID,
                From = worker_has_commentDTO.From,
                FromID = worker_has_commentDTO.FromID,
            };
            await _databaseContext.AddAsync(worker_has_comment);
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker_has_comment has been added");
        }
        [HttpGet]//получение всех Worker_has_comment по ToID, т.е. получение всех комментариев для работника, которому они адрессованы
        [Route("Workerid")]
        public async Task<ActionResult<List<Worker_has_comment>>> GetCommentsforWorkerByID([FromRoute] int Workerid)
        {
            var worker_has_comment = await _databaseContext.workers_has_comments.Where(x => x.ToID == Workerid).ToListAsync();
            return Ok(worker_has_comment);
        }
        [HttpGet]//получение из БД всех Worker_has_comment
        public async Task<ActionResult<List<Worker_has_comment>>> GetAllWorker_has_comment()
        {
            var worker_has_comment = await _databaseContext.workers_has_comments.ToListAsync();
            return Ok(worker_has_comment);
        }
        [HttpPatch]//обновление по id
        [Route("id")]
        public async Task<IActionResult> UpdateWorker_has_comment([FromRoute] int id, [FromBody] CreateWorker_has_commentDTO worker_has_commentDTO)
        {
            var worker_has_comment = await _databaseContext.workers_has_comments.FirstOrDefaultAsync(x => x.WCID == id);
            if (worker_has_comment == null)
            {
                return NotFound("Worker_has_comment not found!");
            }
            worker_has_comment.To = worker_has_commentDTO.To;
            worker_has_comment.ToID = worker_has_commentDTO.ToID;
            worker_has_comment.Comment = worker_has_commentDTO.Comment;
            worker_has_comment.CommentID = worker_has_commentDTO.CommentID;
            worker_has_comment.From = worker_has_commentDTO.From;
            worker_has_comment.FromID = worker_has_commentDTO.FromID;
            await _databaseContext.SaveChangesAsync();
            return Ok("Worker_has_comment has been updated");
        }
        [HttpDelete]//удаление по id
        [Route("id")]
        public async Task<IActionResult> DeleteWorker_has_comment([FromRoute] int id)
        {
            var worker_has_comment = await _databaseContext.workers_has_comments.FirstOrDefaultAsync(x => x.WCID == id);
            if (worker_has_comment == null)
            {
                return NotFound("Worker_has_comment not found!");
            }
            _databaseContext.workers_has_comments.Remove(worker_has_comment);
            return Ok("Worker_has_comment has been deleted");
        }
    }
}