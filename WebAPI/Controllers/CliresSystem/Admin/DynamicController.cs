using Infrastructure.Entities.ProjectsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.CliresSystem.Admin
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    public class DynamicController : ControllerBase
    {
        private readonly ProjectDBContext dbContext;

        public DynamicController(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients =await dbContext.TblStudyCodes.ToListAsync();
            if (patients == null)
                return NotFound();
            return Ok(patients);
        }
    }
}
