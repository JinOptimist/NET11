using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Movies;

public class AddMoviesViewModel
{
    [Required(ErrorMessage = "Ой! Кажется, вы забыли ввести название фильма.")]
    public string Title { get; set; }
}