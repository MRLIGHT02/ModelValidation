using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomModelValidation
{
    public class MCustomValidation : ValidationAttribute
    {
        public override ValidationResult? IsValid(object? value, ValidationContext validationcontext)
        {
            return base.IsValid(value);
        }
    }
}
