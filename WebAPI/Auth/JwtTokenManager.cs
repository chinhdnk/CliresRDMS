using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models;
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

namespace WebAPI.Auth
{
    public class JwtTokenManager: IJwtTokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private readonly IConfiguration configration;
        private readonly CliresSystemDBContext dbContext;
        private byte[] secrectKey;

        public JwtTokenManager(IConfiguration configration, CliresSystemDBContext dbContext)
        {
            this.configration = configration;
            this.dbContext = dbContext;
            tokenHandler = new JwtSecurityTokenHandler();
            secrectKey = Encoding.ASCII.GetBytes(configration.GetValue<string>("JwtSecrectKey"));
        }

        //public string Authenticate(string userName, string password)
        //{
        //    TblAccount item = dbContext.TblAccounts.Find(userName);
        //    //validate the credentials              
        //    if (!string.IsNullOrWhiteSpace(userName) && item.Password != password)
        //        return string.Empty;
        //    else
        //    {
        //        UserLoginModel account = new UserLoginModel(userName, item.Password);
        //    }
        //    //generate token
        //    return CreateToken(account);
        //}

        public string Authenticate(string userName, string password)
        {
            TblAccount item = dbContext.TblAccounts.Find(userName);
            //validate the credentials              
            //if (!string.IsNullOrWhiteSpace(userName) && !BC.Verify(password, item.Password))
            if (!string.IsNullOrWhiteSpace(userName) && password != item.Password)
                return string.Empty;
            else
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                claims.Add(new Claim("FullName", item.FullName));
                claims.Add(new Claim("Email", item.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, configration["Jwt:Subject"]));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));

                //chinh add role admin for tom
                if (userName == "lalala")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(secrectKey),
                            SecurityAlgorithms.HmacSha256Signature
                        )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            
        }

        public string GetUserInfoByToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var jwtToken = tokenHandler.ReadToken(token.Replace("\"", string.Empty)) as JwtSecurityToken;
            var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name");
            if (claim != null) return claim.Value;

            return null;
        }

        public bool VerifyToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

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
            }
            catch (SecurityTokenException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }

            return securityToken != null;
        }
    }
}
