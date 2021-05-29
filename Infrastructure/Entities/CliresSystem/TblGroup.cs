using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupPermissions = new HashSet<TblGroupPermission>();
            TblUserGroups = new HashSet<TblUserGroup>();
        }

        public int GroupId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TblGroupPermission> TblGroupPermissions { get; set; }
        public virtual ICollection<TblUserGroup> TblUserGroups { get; set; }
    }
}
