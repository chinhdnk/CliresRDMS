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
    }
}
