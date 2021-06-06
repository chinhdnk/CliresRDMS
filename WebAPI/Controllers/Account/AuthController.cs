using Infrastructure.Models;
using WebAPI.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers.Auth
{
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IJwtTokenManager jwtTokenManager;
        public AuthController(IJwtTokenManager jwtTokenManager, ILogger<AuthController> logger)
        {
            this.jwtTokenManager = jwtTokenManager;
            this.logger = logger;
        }

        [HttpPost]
        [Route("/authenticate")]
        public Task<string> Authenticate(AuthenticateRequest userCredential)
        {
            string token = jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
            logger.LogInformation($"{userCredential.UserName} authenticate success");
            return Task.FromResult(token);
        }

        [HttpGet]
        [Route("/verifytoken")]
        public Task<string> Verify(string token)
        {
            return Task.FromResult(jwtTokenManager.VerifyToken(token));
        }

        [HttpPost]
        [Route("/getusername")]
        public Task<string> GetUserNameByToken(Token token)
        {
            return Task.FromResult(jwtTokenManager.GetUserNameByToken(token.token));
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(AuthenticateRequest userCredential)
        {
            AuthenticateResponse authenticateResponse = jwtTokenManager.Authenticate2(userCredential.UserName, userCredential.Password);
            logger.LogInformation($"{userCredential.UserName} login success");
            return Ok(authenticateResponse);
        }
    }
    public class Token
    {        
        public string token { get; set; }
    }
}
