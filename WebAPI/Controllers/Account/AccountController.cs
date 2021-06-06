using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using ApplicationCore.Repositories.CiresSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using WebAPI.Auth;

namespace WebAPI.Controllers.Account
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize]
    public class AccountController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly CliresSystemDBContext dbContext;
        private readonly IAccountRepository accountRepository;
        private readonly IJwtTokenManager jwtTokenManager;
        public AccountController(CliresSystemDBContext dbContext, IAccountRepository accountRepository, IJwtTokenManager jwtTokenManager, ILogger<AccountController> logger)
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
            try
            {
                model.Username = jwtTokenManager.GetUserNameByToken(Request.Headers[UserIdentityConstant.TOKEN_HEADER]);
                string result = await accountRepository.ChangePassword(model);
                logger.LogInformation($"{model.Username} change password success");
                return Ok(result);            
            }
            catch(Exception)
            {
                logger.LogError($"{model.Username} change password failed");
                return BadRequest();
            }

        }
    }
}
