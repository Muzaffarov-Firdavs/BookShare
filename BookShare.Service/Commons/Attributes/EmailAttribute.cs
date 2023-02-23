using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookShare.Service.Commons.Attributes;

public class EmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return new ValidationResult("Email can't be empty");
        }
        Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        if (regex.Match(value.ToString()!).Success)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Enter the new Email");
    }
}
