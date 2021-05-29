using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Admin
{
    public class Permission
    {
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int IsAdd { get; set; }
    }
}
