using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserLoginModel(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public UserLoginModel()
        {
        }

        public bool UsernameRequired()
        {
            return !string.IsNullOrWhiteSpace(UserName);
        }

        public bool PasswordRequired()
        {
            return !string.IsNullOrWhiteSpace(Password);
        }
    }

    public class UserIdentity
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
    public class AuthResult
    {
        public string KeyMsg { get; set; }
        public string Token { get; set; }
    }
}
