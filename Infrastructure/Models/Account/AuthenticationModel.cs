using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public AuthenticateRequest(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public AuthenticateRequest()
        {
        }
    }
    public class UserIdentity
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
    public class AuthenticateResponse
    {
        public string KeyMsg { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }

    public class ChangePasswordModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
