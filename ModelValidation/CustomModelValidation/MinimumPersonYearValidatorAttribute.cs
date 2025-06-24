using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomModelValidation
{
    public class MinimumPersonYearValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= 2004)
                {
                    return new ValidationResult("Invalid Date");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
