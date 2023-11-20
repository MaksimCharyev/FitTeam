using FitTeamAPI.Models.Event;
using FitTeamAPI.Models.Role;

namespace FitTeamAPI.DTO.Events
{
    public class RoleOnEventDTO
    {
        public int REID { get; set; }
        public Role? Role { get; set; }
        public int RoleID { get; set; }
        public Event Event { get; set; }
        public int EventID { get; set; }
    }
}
