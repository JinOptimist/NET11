using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.RockHall
{
    public class NewMemberViewModel
    {

        [Required(ErrorMessage = "Пустая пустота, не надо так...")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Пустая пустота, не надо так...")]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Пустая пустота, не надо так...")]
        [Display(Name = "Entry Year in Rock Hall (1950-2023)")]
        [Range(1950, 2023, ErrorMessage = "Ты втираешь мне какую-то дичь")]
        public int EntryYear { get; set; }

        [Required(ErrorMessage = "Пустая пустота, не надо так...")]
        [Display(Name = "Year Of Birth")]
        public int YearOfBirth { get; set; }

    }
}
