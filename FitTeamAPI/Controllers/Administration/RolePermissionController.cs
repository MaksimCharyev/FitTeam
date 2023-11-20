using FitTeamAPI.Context;
using Microsoft.AspNetCore.Mvc;

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
        //Read
        //Update
        //Delete
    }
}
