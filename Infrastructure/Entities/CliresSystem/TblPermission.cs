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
            TblUserPermissions = new HashSet<TblUserPermission>();
        }

        public string PermId { get; set; }
        public bool Status { get; set; }
        public int Menu { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblMenu MenuNavigation { get; set; }
        public virtual ICollection<TblGroupPermission> TblGroupPermissions { get; set; }
        public virtual ICollection<TblUserPermission> TblUserPermissions { get; set; }
    }
}
