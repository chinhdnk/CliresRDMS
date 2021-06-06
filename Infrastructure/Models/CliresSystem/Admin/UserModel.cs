using Infrastructure.Entities.CliresSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.CliresSystem
{
    public class UserModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MPhone { get; set; }
        public string OPhone { get; set; }
        public string ESignature { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Institution { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserModel() { }
        public UserModel(TblUser item)
        {
            Username = item.Username;
            FullName = item.FullName;
            Email = item.Email;
            MPhone = item.MPhone;
            OPhone = item.OPhone;
            ESignature = item.ESignature;
            City = item.City;
            Country = item.Country;
            Institution = item.Institution;
            Status = item.Status;
            CreatedBy = item.CreatedBy;
            CreatedDate = item.CreatedDate;

        }
    }
}
