using FitTeamAPI.Context;
using FitTeamAPI.DTO.Administration;
using FitTeamAPI.Models.Role;
using FitTeamAPI.Models.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitTeamAPI.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public RolePermissionController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO RoleDTO)
        {
            var role = new Role()
            {
               RoleName = RoleDTO.RoleName,
               RoleDescription = RoleDTO.RoleDescription,
            };
            await _databaseContext.AddAsync(role);
            await _databaseContext.SaveChangesAsync();
            return Ok("Role has been added");
        }
        //Read
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Role>> GetRoleByID([FromRoute] int id)
        {
            var role = await _databaseContext.roles.FirstOrDefaultAsync(x => x.RoleID == id);
            if(role == null)
            {
                return NotFound("Role not found!");
            }
            return Ok(role);
        }
        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetWorkers()
        {
            var roles = await _databaseContext.roles.ToListAsync();
            return Ok(roles);
        }
        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] CreateRoleDTO RoleDTO)
        {
            var role = await _databaseContext.roles.FirstOrDefaultAsync(x => x.RoleID == id);
            if (role == null)
            {
                return NotFound("Role not found!");
            }
            role.RoleDescription = RoleDTO.RoleDescription;
            role.RoleName = RoleDTO.RoleName;
            await _databaseContext.SaveChangesAsync();
            return Ok("Role has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var role = await _databaseContext.roles.FirstOrDefaultAsync(x => x.RoleID == id);
            if (role == null)
            {
                return NotFound("Role not found!");
            }
            _databaseContext.roles.Remove(role);
            await _databaseContext.SaveChangesAsync();
            return Ok("Role has been deleted");
        }
        //Create
        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDTO PermDTO)
        {
            var perm = new Permission
            {
                PermissionDescription = PermDTO.Description,
                PermissionName = PermDTO.Name,
            }
            await _databaseContext.permissions.AddAsync(perm);
            await _databaseContext.SaveChangesAsync();
            return Ok("Permission has been added");
        }
        //Read
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Permission>> GetPermissionByID([FromRoute] int id)
        {
            var perm = await _databaseContext.permissions.FirstOrDefaultAsync(x => x.PermissionID == id);
            if(perm == null) 
            {
                return NotFound("Permisiion not found!");
            }
            return Ok(perm);
        }
        [HttpGet]
        public async Task<ActionResult<List<Permission>>> GetPermissions()
        {
            var perms = await _databaseContext.permissions.ToListAsync();
            return Ok(perms);
        }
        //Update
        [HttpPatch]
        [Route("id")]
        public async Task<IActionResult> UpdatePermission([FromRoute] int id, [FromBody] CreatePermissionDTO PermDTO)
        {
            var perm = await _databaseContext.permissions.FirstOrDefaultAsync(x => x.PermissionID == id);
            if (perm == null)
            {
                return NotFound("Permission not found!");
            }
            perm.PermissionName = PermDTO.Name;
            perm.PermissionDescription = PermDTO.Description;
            await _databaseContext.SaveChangesAsync();
            return Ok("Permission has been updated");
        }
        //Delete
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeletePermission([FromRoute] int id)
        {
            var perm = await _databaseContext.permissions.FirstOrDefaultAsync(_ => _.PermissionID == id);
            if(perm == null)
            {
                return NotFound("Permission not found!");
            }
            _databaseContext.permissions.Remove(perm);
            await _databaseContext.SaveChangesAsync();
            return Ok("Permission has been deleted");
        }
    }
}
}
