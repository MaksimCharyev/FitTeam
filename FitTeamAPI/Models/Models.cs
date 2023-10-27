using System.ComponentModel.DataAnnotations;
namespace FitTeamAPI.Models
{
    public class Worker
    {
        [Key] 
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        
    }
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
    }

}
