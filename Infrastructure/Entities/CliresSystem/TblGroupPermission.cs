using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblGroupPermission
    {
        public int GroupId { get; set; }
        public int PermId { get; set; }

        public virtual TblGroup Group { get; set; }
        public virtual TblPermission Perm { get; set; }
    }
}
