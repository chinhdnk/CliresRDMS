using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblMenu
    {
        public TblMenu()
        {
            TblMenuPermissions = new HashSet<TblMenuPermission>();
        }

        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int? ParentId { get; set; }
        public int Sort { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TblMenuPermission> TblMenuPermissions { get; set; }
    }
}
