using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.CustomModelValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Person : IValidatableObject
    {
        [Required]
        public string? PersonName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "invalid Email")]
        [TempData]
        public string? Email { get; set; }
        public long? Phone { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        [PasswordPropertyText]
        public string? ConfirmPassword { get; set; }
        [Required]
        public double? Price { get; set; }

        [MinimumPersonYearValidator(2000, ErrorMessage = "Age must be less than {0}")]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either Age or Date Of Birth Should Be Suppllied", new[] { nameof(Age), nameof(DateOfBirth) });
            }
        }
        public override string ToString()
        {
            return $"Name: {this.PersonName} Email: {this.Email} Phone: {this.Phone} Passowrd: {Password} Conform:{this.ConfirmPassword} Price: {this.Price} DateOfBirth: {this.DateOfBirth}";
        }

    }
}
