using System;
using Infrastructure.Entities.CliresSystem;

namespace Infrastructure.Models.CliresSystem
{
    public class Permission
    {
        public string PermissionID { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Permission() { }
        public Permission(TblPermission permission)
        {
            PermissionID = permission.PermId;
            MenuId = permission.Menu;
            Status = permission.Status;
            CreatedBy = permission.CreatedBy;
            CreatedDate = permission.CreatedDate;
            ModifiedBy = permission.ModifiedBy;
            ModifiedDate = permission.ModifiedDate;
        }
    }
}
