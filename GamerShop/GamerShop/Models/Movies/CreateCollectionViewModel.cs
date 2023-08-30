using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Movies;

public class CreateCollectionViewModel
{
    [Required(ErrorMessage = "Поле 'Название подборки' обязательно.")]
    [StringLength(100, ErrorMessage = "Максимальная длина названия подборки - 100 символов.")]
    public string Title { get; set; }

    [StringLength(500, ErrorMessage = "Максимальная длина описания - 500 символов.")]
    public string? Description { get; set; }

    public List<ShortMovieViewModelToAddInCollection> AvailableMovies { get; set; }
}