using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.RockHall
{
    public class NewBandViewModel
    {

        [Required(ErrorMessage = "Пустая пустота, не надо так...")]
        [Display(Name = "Band Name")]
        public string FullName { get; set; }

    }
}
