using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
using ApplicationCore.Repositories.CiresSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebAPI.Auth
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private readonly IConfiguration configuration;
        private readonly CliresSystemDBContext dbContext;
        private readonly IPermissionRepository permissionRepository;
        private byte[] secrectKey;

        public JwtTokenManager(IConfiguration configuration, CliresSystemDBContext dbContext, IPermissionRepository permissionRepository)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.permissionRepository = permissionRepository;
            tokenHandler = new JwtSecurityTokenHandler();
            secrectKey = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        }

        public AuthenticateResponse Authenticate(string userName, string password)
        {
            AuthenticateResponse authenticateResponse = new AuthenticateResponse();
            try
            {
                TblAccount account = dbContext.TblAccounts.Find(userName);
                if (account == null || !BC.Verify(account.Salt + password, account.Password))
                {
                    authenticateResponse.KeyMsg = "username_pw_incorrect";
                    authenticateResponse.Token = string.Empty;
                }
                else
                {
                    IQueryable<string> listPerm = permissionRepository.GetPermOfUser(userName);
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, userName));
                    claims.Add(new Claim(UserIdentityConstant.FULL_NAME, account.FullName));
                    claims.Add(new Claim(UserIdentityConstant.EMAIL, account.Email));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));

                    foreach (var perm in listPerm)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, perm));
                    }

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(secrectKey),
                                SecurityAlgorithms.HmacSha256Signature
                            )
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    authenticateResponse.Username = userName;
                    authenticateResponse.Token = tokenHandler.WriteToken(token);
                    authenticateResponse.KeyMsg = "login_success";
                }
            }
            catch (Exception)
            {
                authenticateResponse.KeyMsg = "login_fail";
            }
            return authenticateResponse;
        }

        public string GetUserNameByToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var jwtToken = tokenHandler.ReadToken(token.Replace("\"", string.Empty)) as JwtSecurityToken;
            var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == UserIdentityConstant.UNIQUE_NAME);
            if (claim != null) return claim.Value;

            return null;
        }

        public UserIdentity GetUserInfoByToken(string token)
        {
            UserIdentity userIdentity = new UserIdentity();
            if (string.IsNullOrWhiteSpace(token)) return null;
            var jwtToken = tokenHandler.ReadToken(token.Replace("\"", string.Empty)) as JwtSecurityToken;
            var claimUserName = jwtToken.Claims.FirstOrDefault(x => x.Type == UserIdentityConstant.UNIQUE_NAME);
            if (claimUserName != null) userIdentity.Username = claimUserName.ToString();
            var claimFullName = jwtToken.Claims.FirstOrDefault(x => x.Type == UserIdentityConstant.FULL_NAME);
            if (claimFullName != null) userIdentity.FullName = claimFullName.ToString();
            var claimEmail = jwtToken.Claims.FirstOrDefault(x => x.Type == UserIdentityConstant.EMAIL);
            if (claimEmail != null) userIdentity.Email = claimEmail.ToString();

            return userIdentity;
        }

        public string VerifyToken(string token )
        {
            if (string.IsNullOrWhiteSpace(token)) return null;

            SecurityToken securityToken;

            try
            {
                tokenHandler.ValidateToken(
                token.Replace("\"", string.Empty),
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secrectKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                },
                out securityToken);
                var jwtToken = (JwtSecurityToken)securityToken;
                var username = jwtToken.Claims.First(x => x.Type == UserIdentityConstant.UNIQUE_NAME).Value;
                return username;
            }
            catch (SecurityTokenException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
