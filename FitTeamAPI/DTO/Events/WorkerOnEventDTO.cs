using FitTeamAPI.Models.Event;
using FitTeamAPI.Models.Worker;

namespace FitTeamAPI.DTO.Events
{
    public class WorkerOnEventDTO
    {
        public int WEID { get; set; }
        public Worker Worker { get; set; }
        public int WorkerID { get; set; }
        public Event Event { get; set; }
        public int EventID { get; set; }
    }
}
