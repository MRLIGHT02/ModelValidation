using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomModelValidation
{
    public class MinimumPersonYearValidatorAttribute : ValidationAttribute
    {
        public override ValidationResult? IsValid(object? value, ValidationContext validationcontext)
        {
            return new ValidationResult("message");
        }
    }
}
