using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using Microsoft.AspNetCore.Http;
using WebAPI.Auth;
using Infrastructure.Constant;
using ApplicationCore.Repositories.CliresSystem;

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
