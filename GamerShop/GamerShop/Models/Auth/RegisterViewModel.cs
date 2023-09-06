using GamerShop.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Auth
{
    public class RegisterViewModel
    {
        [Required]
        [UniqName(ErrorMessage = "Имя уже используется")]
        public string Login { get; set; }

        [Required]
        [AtLeastOneCapitalAtLeastOneNotCapital(ErrorMessage = "Хотя бы одну большую букву")]
        public string Password { get; set; }
    }
}
