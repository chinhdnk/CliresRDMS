using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblPasswordHistory
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TblUser UsernameNavigation { get; set; }
    }
}
