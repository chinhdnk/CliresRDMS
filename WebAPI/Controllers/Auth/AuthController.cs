using Infrastructure.Models;
using WebAPI.Auth;
using Infrastructure.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Auth
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenManager jwtTokenManager;
        public AuthController(IJwtTokenManager jwtTokenManager)
        {
            this.jwtTokenManager = jwtTokenManager;
        }

        [HttpPost]
        [Route("/authenticate")]
        public Task<string> Authenticate(UserLoginModel userCredential)
        {
            string token = jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
            return Task.FromResult(token);

        }

        [HttpGet]
        [Route("/verifytoken")]
        public Task<bool> Verify(string token)
        {
            return Task.FromResult(jwtTokenManager.VerifyToken(token));
        }

        [HttpPost]
        [Route("/getuserinfo")]
        public Task<string> GetUserInfoByToken(Token token)
        {
            return Task.FromResult(jwtTokenManager.GetUserInfoByToken(token.token));
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(UserLoginModel userCredential)
        {
            AuthResult authResult = jwtTokenManager.Authenticate2(userCredential.UserName, userCredential.Password);
            return Ok(authResult);
        }
    }
    public class Token
    {        public string token { get; set; }
    }
}
