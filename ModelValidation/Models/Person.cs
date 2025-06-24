using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Person
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


        public override string ToString()
        {
            return $"Name: {this.PersonName} Email: {this.Email} Phone: {this.Phone} Passowrd: {Password} Conform:{this.ConfirmPassword} Price: {this.Price}";
        }
    }
}
