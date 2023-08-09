using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models
{
    public class AuthViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [MaxLength(10)]
        public string Password { get; set; }

        [Range(1, 100, ErrorMessage = "Мы тебе не верим")]
        public int Age { get; set; }
    }
}
