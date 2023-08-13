using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models
{
    public class CarViewModel
    {
        [Required]
        public string NameCar { get; set; }
        [Required]
        public string InfoAboutCar { get; set; }

    }
}
