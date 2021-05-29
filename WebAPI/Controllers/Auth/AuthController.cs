using Infrastructure.Models;
using Infrastructure.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Auth;

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
            return Task.FromResult(jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password));

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

        //[HttpPost]
        //[Route("/register")]
        //public async Task<IActionResult> Register(SignUp model)
        //{
        //    return Ok();
        //}
    }
    public class Token
    {        public string token { get; set; }
    }
}
