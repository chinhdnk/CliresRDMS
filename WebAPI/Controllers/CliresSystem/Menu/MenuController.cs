using Infrastructure.Entities.CliresSystem;
using Infrastructure.Repositories.CiresSystem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebAPI.Controllers.CliresSystem
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository menuRepository;
        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return Ok( menuRepository.GetMenuList("chinhdnk"));
        }
    }
}
