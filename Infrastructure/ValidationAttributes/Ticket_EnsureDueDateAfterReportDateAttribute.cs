using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Models;

namespace Infrastructure.ValidationAttributes
{
    public class Ticket_EnsureDueDateAfterReportDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateDueDateAfterReportDate())
                return new ValidationResult("Due date has to be after Report date.");

            return ValidationResult.Success;
        }
    }
}
