using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblUserGroup
    {
        public string Username { get; set; }
        public int GroupId { get; set; }

        public virtual TblGroup Group { get; set; }
        public virtual TblUser UsernameNavigation { get; set; }
    }
}
