using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblPermission
    {
        public TblPermission()
        {
            TblGroupPermissions = new HashSet<TblGroupPermission>();
            TblMenuPermissions = new HashSet<TblMenuPermission>();
            TblUserPermissions = new HashSet<TblUserPermission>();
        }

        public int PermId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TblGroupPermission> TblGroupPermissions { get; set; }
        public virtual ICollection<TblMenuPermission> TblMenuPermissions { get; set; }
        public virtual ICollection<TblUserPermission> TblUserPermissions { get; set; }
    }
}
