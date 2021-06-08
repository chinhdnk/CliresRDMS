using Infrastructure.Entities.CliresSystem;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.CliresSystem
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int IsAdd { get; set; }

        public List<Permission> ListPermission { get; set; }

        public Group() { }
        public Group(TblGroup item)
        {
            GroupID = item.GroupId;
            GroupName = item.Title;
            Status = item.Status;
            CreatedDate = item.CreatedDate;
            CreatedBy = item.CreatedBy;
            ModifiedBy = item.ModifiedBy;
            ModifiedDate = item.ModifiedDate;
        }
    }
}
