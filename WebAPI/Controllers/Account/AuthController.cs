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
        private readonly IJwtTokenManager jwtTokenManager;
        public AuthController(IJwtTokenManager jwtTokenManager)
        {
            this.jwtTokenManager = jwtTokenManager;
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
        [Route("/authenticate")]
        public IActionResult Authenticate(AuthenticateRequest userCredential)
        {
            AuthenticateResponse authenticateResponse = jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
            return Ok(authenticateResponse);
        }
    }
    public class Token
    {        
        public string token { get; set; }
    }
}
