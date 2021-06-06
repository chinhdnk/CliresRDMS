using Infrastructure.Constant;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;
using WebAPI.Auth;

namespace WebApi.Filters
{
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {       
        private string TokenHeader = UserIdentityConstant.TOKEN_HEADER;
        private readonly string[] allowedRoles;
        public JwtAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        //public void OnAuthorization(AuthorizationFilterContext context)
        //{

        //    if (!context.HttpContext.Request.Headers.TryGetValue(TokenHeader, out var token))
        //    {
        //        context.Result = new UnauthorizedResult();
        //        return;
        //    }

        //    var tokenManager = context.HttpContext.RequestServices.GetService(typeof(IJwtTokenManager)) as IJwtTokenManager;
        //    string username = tokenManager.VerifyToken(token);
        //    if (tokenManager == null || string.IsNullOrWhiteSpace(username))
        //    {
        //        context.Result = new UnauthorizedResult();
        //        return;
        //    }
        //    context.HttpContext.Items[UserIdentityConstant.USERNAME] = username;
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(TokenHeader, out var token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenManager = context.HttpContext.RequestServices.GetService(typeof(IJwtTokenManager)) as IJwtTokenManager;
            string username = tokenManager.VerifyToken(token);
            if (tokenManager == null || string.IsNullOrWhiteSpace(username))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            else
            {
                bool flagClaim = false;
                context.HttpContext.Items[UserIdentityConstant.USERNAME] = username;
                if (allowedRoles == null ||allowedRoles.Length==0)
                    flagClaim = true;
                else
                {
                    var roles = context.HttpContext.User.Claims;
                    foreach (var item in allowedRoles)
                    {
                        if (context.HttpContext.User.HasClaim("Role", item))
                            flagClaim = true;
                    }
                }
                if (!flagClaim)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

            }
        }
    }
}
