using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.CustomValidationAttribute;

public class AtLeastOneMovieSelectedAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is List<SelectListItem> availableMovies)
        {
            if (!availableMovies.Any(movie => movie.Selected))
                return new ValidationResult(ErrorMessage ?? "Необходимо выбрать хотя бы один фильм.");
        }
        return ValidationResult.Success;
    }
}