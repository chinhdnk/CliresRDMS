using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblUserPermission
    {
        public string Username { get; set; }
        public string PermId { get; set; }

        public virtual TblPermission Perm { get; set; }
        public virtual TblUser UsernameNavigation { get; set; }
    }
}
