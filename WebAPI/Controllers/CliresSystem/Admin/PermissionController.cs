using Infrastructure.Entities.CliresSystem;
using ApplicationCore.Repositories.CiresSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using Infrastructure.Models.CliresSystem;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Controllers.CliresSystem
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly CliresSystemDBContext dbContext;
        private readonly ILoggerManager logger;
        public PermissionController(IPermissionRepository permissionRepository, CliresSystemDBContext dbContext, ILoggerManager logger)
        {
            this.permissionRepository = permissionRepository;
            this.dbContext = dbContext;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            logger.LogInfo($"fetching all permission from the storage");
            var permList = await permissionRepository.GetPermissionList();
            logger.LogInfo($"Returning {permList.Count()} permission");
            return Ok(permList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            TblPermission item = await dbContext.TblPermissions.Where(x => x.PermId == id).FirstOrDefaultAsync();
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Permission perm)
        {
            string permId = await permissionRepository.CreatePermission(perm);
            if (permId == null)
                return NotFound();
            return Ok(permId);
        }

        [HttpPut("{permId}")]
        public async Task<IActionResult> Put(string permId, Permission permission)
        {
            if (permId != permission.PermissionID) return BadRequest();
            int result= await permissionRepository.UpdatePermission(permId, permission);
            if (result != 0)
                return NotFound();
            return Ok(permission);
        }
    }
}
