using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
                PropertyInfo? otherPropertyName = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherPropertyName is not null)
                {

                    DateTime from_date = Convert.ToDateTime(otherPropertyName.GetValue(validationContext.ObjectInstance));
                    if (from_date > to_date)
                    {

                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });

                    }
                    else
                    {
                        return ValidationResult.Success;
                    }

                }
                return null;
            }
            return null;
        }
    }
}
