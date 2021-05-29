using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Models;

namespace Infrastructure.ValidationAttributes
{
    public class Ticket_EnsureDueDatePresentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (!ticket.ValidateDueDatePresence())
                return new ValidationResult("Due date is required.");

            return ValidationResult.Success;
        }
    }
}
