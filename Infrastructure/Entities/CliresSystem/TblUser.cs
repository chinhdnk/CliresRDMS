using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPasswordHistories = new HashSet<TblPasswordHistory>();
            TblUserGroups = new HashSet<TblUserGroup>();
            TblUserPermissions = new HashSet<TblUserPermission>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MPhone { get; set; }
        public string OPhone { get; set; }
        public string ESignature { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Institution { get; set; }
        public byte Status { get; set; }
        public bool? OnLogin { get; set; }
        public DateTime? LastLogin { get; set; }
        public byte? WrongTime { get; set; }
        public DateTime? ResetPwDate { get; set; }
        public string ResetPwKey { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TblPasswordHistory> TblPasswordHistories { get; set; }
        public virtual ICollection<TblUserGroup> TblUserGroups { get; set; }
        public virtual ICollection<TblUserPermission> TblUserPermissions { get; set; }
    }
}
