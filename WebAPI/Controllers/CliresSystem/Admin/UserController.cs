using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using Infrastructure.Models.Admin;
using Infrastructure.Constant;
using ApplicationCore.Repositories.CliresSystem;

namespace WebAPI.Controllers.CliresSystem.Admin
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await userRepository.GetUserList());
        }
    }
}
