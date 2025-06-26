using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomModelValidation
{

    public class DateRangeValidator : ValidationAttribute
    {
        string OtherPropertyName { get; set; }


        public DateRangeValidator(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                DateTime to_date = Convert.ToDateTime(value);
            }
        }
    }
}
