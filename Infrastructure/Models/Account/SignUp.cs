using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Admin
{
    public class SignUp
    {
        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(50, ErrorMessage = "The length of full name is not greather than 50 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is requried")]
        [MaxLength(55, ErrorMessage = "The length of email is not greather than 55 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(12, ErrorMessage = "The length of mobile phone is not greather than 12 characters")]
        public string MobilePhone { get; set; }

        [MaxLength(12, ErrorMessage = "The length of office phone is not greather than 12 characters")]
        public string OfficePhone { get; set; }

        [MaxLength(250, ErrorMessage = "The length of city is not greather than 250 characters")]
        public string City { get; set; }

        [MaxLength(3, ErrorMessage = "The length of country code is not greather than 3 characters")]
        public string Country { get; set; }

        [MaxLength(500, ErrorMessage = "The length of institution is not greather than 500 characters")]
        public string Institution { get; set; }

        [MaxLength(500, ErrorMessage = "The length of registration project is not greather than 500 characters")]
        public string RegisteredProject { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
