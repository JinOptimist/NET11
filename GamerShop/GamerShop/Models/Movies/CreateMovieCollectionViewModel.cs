using System.ComponentModel.DataAnnotations;
using GamerShop.Models.CustomValidationAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Models.Movies;

public class CreateMovieCollectionViewModel
{
    [Required(ErrorMessage = "Поле 'Название подборки' обязательно.")]
    [StringLength(100, ErrorMessage = "Максимальная длина названия подборки - 100 символов.")]
    public string Title { get; set; }

    [StringLength(500, ErrorMessage = "Максимальная длина описания - 500 символов.")]
    public string? Description { get; set; }

    [AtLeastOneMovieSelectedAttribute(ErrorMessage = "Необходимо выбрать хотя бы один фильм.")]
    public List<SelectListItem> AvailableMovies { get; set; }
}