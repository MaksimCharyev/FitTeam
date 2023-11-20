using FitTeamAPI.Models.Event;
using FitTeamAPI.Models.Subdivision;

namespace FitTeamAPI.DTO.Activity.Events
{
    public class SubdivisionOnEventDTO
    {
        public int SEID { get; set; }
        public Subdivision Subdivision { get; set; }
        public int SubdivisionID { get; set; }
        public Event Event { get; set; }
        public int EventID { get; set; }
    }
}
