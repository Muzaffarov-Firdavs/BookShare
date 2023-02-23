using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookShare.Service.Commons.Attributes
{
    internal class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            Regex regex = new Regex("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$");

            return regex.Match(value.ToString()!).Success ? ValidationResult.Success
                : new ValidationResult("Plese enter currect phone number))");
        }
    }
}
