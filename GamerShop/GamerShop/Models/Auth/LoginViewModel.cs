using GamerShop.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
