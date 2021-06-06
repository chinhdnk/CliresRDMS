using Infrastructure.Entities.CliresSystem;
using ApplicationCore.Repositories.CiresSystem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Auth;
using Infrastructure.Constant;

namespace WebAPI.Controllers.CliresSystem
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;
        private readonly IJwtTokenManager jwtTokenManager;
        public MenuController(IMenuRepository menuRepository, IJwtTokenManager jwtTokenManager)
        {
            this.menuRepository = menuRepository;
            this.jwtTokenManager = jwtTokenManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var username = HttpContext.Items[UserIdentityConstant.USERNAME].ToString();
            return Ok( menuRepository.GetMenuList(username));
        }
    }
}
