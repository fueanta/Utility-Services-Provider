using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models.CustomValidations
{
    public class CustomValidationForPassword : ValidationAttribute
    {
        private static readonly int MinLength = 6;
        private static readonly int MaxLength = 25;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            var password = user.Password;
            var errorMsg = "";
            var lineBreak = "<br/>";

            if (string.IsNullOrEmpty(password))
                errorMsg = "Password is required";
            else
            {
                if (password.Length < MinLength)
                    errorMsg += $"*Password should contain at least {MinLength} characters" + lineBreak;
                if (password.Length > MaxLength)
                    errorMsg += $"*Password should not contain more than {MaxLength} characters" + lineBreak;
                if (!password.Any(p => !char.IsLetterOrDigit(p)))
                    errorMsg += $"*Password should contain at least one special character";
            }

            if (!string.IsNullOrEmpty(errorMsg))
                return new ValidationResult(errorMsg);
            else return ValidationResult.Success;
        }
    }
}