using e_commerce.viewmodels;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.custom_valiation
{
    public class optionalpasswordforediting:ValidationAttribute

    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = (UserEditVM)validationContext.ObjectInstance;

           
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return ValidationResult.Success;
            }

            if (string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return new ValidationResult("Confirm Password is required.");
            }

        
            if (model.NewPassword != model.ConfirmPassword)
            {
                return new ValidationResult("Passwords do not match.");
            }

          
            if (model.NewPassword.Length < 14)
            {
                return new ValidationResult("Password must be at least 14 characters.");
            }

            return ValidationResult.Success;
        }
    }
}
    

