using FitTeamAPI.Context;
using FitTeamAPI.DTO.Activity;
using FitTeamAPI.Models.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Activity
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public CommentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO commentDTO)
        {
            var comment = new Comment()
            {
                CommentDescription = commentDTO.CommentDescription,
                CommentType = commentDTO.CommentType,
                IsClosed = commentDTO.IsClosed,
            };
            await _databaseContext.AddAsync(comment);
            await _databaseContext.SaveChangesAsync();
            return Ok("Comment has been added");
        }
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Comment>> GetCommentByID([FromRoute] int id)
        {
            var comment = await _databaseContext.comments.FirstOrDefaultAsync(x => x.CommentID == id);
            return Ok(comment);
        }
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comment = await _databaseContext.comments.ToListAsync();
            return Ok(comment);
        }
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] CreateCommentDTO commentDTO)
        {
            var comment = await _databaseContext.comments.FirstOrDefaultAsync(x => x.CommentID == id);
            if (comment == null)
            {
                return NotFound("Comment not found!");
            }
            comment.CommentDescription = commentDTO.CommentDescription;
            comment.CommentType = commentDTO.CommentType;
            comment.IsClosed = commentDTO.IsClosed;
            await _databaseContext.SaveChangesAsync();
            return Ok("Comment has been updated");
        }
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await _databaseContext.comments.FirstOrDefaultAsync(x => x.CommentID == id);
            if (comment == null)
            {
                return NotFound("Comment not found!");
            }
            _databaseContext.comments.Remove(comment);
            return Ok("Comment has been deleted");
        }
    }
}
