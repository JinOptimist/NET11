using BusinessLayerInterfaces.UserServices;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.CustomValidationAttribute
{
    public class UniqNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value.GetType() != typeof(string))
            {
                throw new ArgumentException("We can user the attribute only with strings");
            }

            if (value == null)
            {
                var result = new ValidationResult("Name can not be empty");
                return result;
            }

            var userService = validationContext.GetRequiredService<IUserService>();
            if (userService.IsUserNameExist((string)value))
            {
                var result = new ValidationResult(ErrorMessage);
                return result;
            }

            return ValidationResult.Success;
        }
    }
}
