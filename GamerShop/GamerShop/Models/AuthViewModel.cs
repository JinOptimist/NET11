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
    }
}
