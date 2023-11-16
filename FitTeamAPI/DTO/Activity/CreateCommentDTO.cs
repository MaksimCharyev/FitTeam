namespace FitTeamAPI.DTO.Activity
{
    public class CreateCommentDTO
    {
        public string CommentDescription { get; set; }
        public int CommentType { get; set; }
        public bool IsClosed { get; set; }
    }
}
