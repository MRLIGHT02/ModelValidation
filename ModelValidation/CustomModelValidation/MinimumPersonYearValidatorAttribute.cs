using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomModelValidation
{
    public class MinimumPersonYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        public string DefaultErrorMessage { get; set; } = "Year Should Be Less than {0}";
        public MinimumPersonYearValidatorAttribute()
        {

        }
        public MinimumPersonYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage??DefaultErrorMessage,MinimumYear));
                }
                else
                {
                    date.GetDateTimeFormats();
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
