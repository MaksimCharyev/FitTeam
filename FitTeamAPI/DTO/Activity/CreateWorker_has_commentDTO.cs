using FitTeamAPI.Models.Comment;
using FitTeamAPI.Models.Worker;

namespace FitTeamAPI.DTO.Activity
{
    public class CreateWorker_has_commentDTO
    {
        public Worker? To { get; set; }
        public int ToID { get; set; }
        public Comment? Comment { get; set; }
        public int CommentID { get; set; }
        public Worker? From { get; set; }
        public int FromID { get; set; }
    }
}