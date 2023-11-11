using FitTeamAPI.Models.Norm;
using FitTeamAPI.Models.Worker;

namespace FitTeamAPI.DTO.Activity
{
    public class CreateWorker_does_normDTO
    {
        public Worker? Worker { get; set; }
        public int WorkerID { get; set; }
        public Norm? Norm { get; set; }
        public int NormID { get; set; }
        public DateTime NormTime { get; set; }
        public string Mark { get; set; }
        public Worker? Host { get; set; }
        public int HostID { get; set; }
    }
}
