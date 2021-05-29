using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblMenuPermission
    {
        public int MenuId { get; set; }
        public int PermId { get; set; }

        public virtual TblMenu Menu { get; set; }
        public virtual TblPermission Perm { get; set; }
    }
}
