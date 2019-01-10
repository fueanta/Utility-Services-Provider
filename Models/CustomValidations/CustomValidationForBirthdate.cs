using System;
using System.ComponentModel.DataAnnotations;

namespace Models.CustomValidations
{
    public class CustomValidationForBirthdate : ValidationAttribute
    {
        private static readonly int MinAge = 18;
        private static readonly int MaxAge = 80;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            var dateOfBirth = user.DateOfBirth;

            if (CalculateAge(dateOfBirth) < MinAge)
                return new ValidationResult($"You must be at least {MinAge} years old");
            else if (CalculateAge(dateOfBirth) > MaxAge)
                return new ValidationResult($"People more than {MaxAge} years old cannot register");
            else
                return ValidationResult.Success;
        }

        private int CalculateAge(DateTime dob)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - dob.Year;
            // Go back to the year the person was born in case of a leap year
            if (dob > today.AddYears(-age)) age--;
            // Return the age
            return age;
        }
    }
}