using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Filters;
using WebAPI.Auth;
using Infrastructure.Services;
using ApplicationCore.Repositories.Account;

namespace WebAPI.Controllers.Account
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize]
    public class AccountController : ControllerBase
    {
        private readonly ILoggerManager logger;
        private readonly CliresSystemDBContext dbContext;
        private readonly IAccountRepository accountRepository;
        private readonly IJwtTokenManager jwtTokenManager;
        public AccountController(CliresSystemDBContext dbContext, IAccountRepository accountRepository, IJwtTokenManager jwtTokenManager, ILoggerManager logger)
        {
            this.dbContext = dbContext;
            this.accountRepository = accountRepository;
            this.jwtTokenManager = jwtTokenManager;
            this.logger = logger;
        }

        [HttpPost]
        [Route("/changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            logger.LogInfo($"{model.Username} request to change password");
            model.Username = jwtTokenManager.GetUserNameByToken(Request.Headers[UserIdentityConstant.TOKEN_HEADER]);
            string result = await accountRepository.ChangePassword(model);
            logger.LogInfo($"{model.Username} change password success");
            return Ok(result);
        }
    }
}
