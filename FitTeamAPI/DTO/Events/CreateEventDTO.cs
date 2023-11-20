using FitTeamAPI.Models.Worker;

namespace FitTeamAPI.DTO.Events
{
    public class CreateEventDTO
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventTime { get; set; }
        public Worker? Host { get; set; }
    }
}
