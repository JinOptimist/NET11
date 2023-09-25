

using BusinessLayerInterfaces.BusinessModels.Movies;
using DALInterfaces.Models.Movies;
using GamerShop.Models.Movies;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Books
{
    public class NewBookViewModel
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public List<Movie> FilmAdaptations { get; set; }
    }
}
