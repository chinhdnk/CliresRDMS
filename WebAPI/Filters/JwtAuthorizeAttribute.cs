using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebAPI.Auth;

namespace WebApi.Filters
{
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {       
        private string TokenHeader = "TokenHeader";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserIdentity)context.HttpContext.Items["User"];
            if (!context.HttpContext.Request.Headers.TryGetValue(TokenHeader, out var token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenManager = context.HttpContext.RequestServices.GetService(typeof(IJwtTokenManager)) as IJwtTokenManager;       
            if (tokenManager == null || !tokenManager.VerifyToken(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
