using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.CustomValidationAttribute
{
    public class AtLeastOneCapitalAtLeastOneNotCapitalAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? $"Do not forget add to {name} at least one AAAA or zzzz";
        }
        public override bool IsValid(object? value)
        {
            if (value != null && value.GetType() != typeof(string))
            {
                throw new ArgumentException("We can user the attribute only with strings");
            }

            if (value == null)
            {
                return false;
            }

            var str = (string)value;

            return !(str.ToUpper() == str || str.ToLower() == str);
        }
    }
}
