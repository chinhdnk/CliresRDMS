using Infrastructure.Constant;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ApplicationCore.Repositories.Account;

namespace CliresWeb
{
    public class JwtTokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ITokenRepository tokenRepository;

        public JwtTokenAuthenticationStateProvider(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = await tokenRepository.GetToken();

            if (!string.IsNullOrWhiteSpace(tokenString))
            {
                var tokenJwt = tokenHandler.ReadToken(tokenString.Replace("\"", string.Empty)) as JwtSecurityToken;

                if (tokenJwt != null)
                {
                    var claims = new List<Claim>();
                    claims.AddRange(tokenJwt.Claims);

                    var nameClaim = tokenJwt.Claims.FirstOrDefault(x => x.Type == UserIdentityConstant.UNIQUE_NAME);
                    var roleClaims = tokenJwt.Claims.Where(x => x.Type == UserIdentityConstant.ROLE);
                    if (nameClaim != null) claims.Add(new Claim(ClaimTypes.Name, nameClaim.Value));
                    if (roleClaims != null)
                    {
                        foreach(var role in roleClaims)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.Value));
                        }
                    }

                    var identity = new ClaimsIdentity(claims, UserIdentityConstant.TOKEN_AUTH);
                    var principal = new ClaimsPrincipal(identity);

                    return new AuthenticationState(principal);
                }
                else
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
