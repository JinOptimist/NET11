using GamerShop.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models
{
    public class AuthViewModel
    {
        [Required]
        [AtLeastOneCapitalAtLeastOneNotCapital]
        public string Login { get; set; }

        [Required]
        [MaxLength(10)]
        [AtLeastOneCapitalAtLeastOneNotCapital(ErrorMessage = "Хотя бы одну большую букву")]
        public string Password { get; set; }
    }
}
