using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte Status { get; set; }
        public bool? OnLogin { get; set; }
        public DateTime? LastLogin { get; set; }
        public byte? WrongTime { get; set; }
        public DateTime? ResetPwDate { get; set; }
        public string ResetPwKey { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Salt { get; set; }
    }
}
