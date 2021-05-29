using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities.CliresSystem
{
    public partial class TblSignUp
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MPhone { get; set; }
        public string OPhone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Institution { get; set; }
        public byte? Status { get; set; }
        public string RegProject { get; set; }
        public DateTime? RegDate { get; set; }
    }
}
