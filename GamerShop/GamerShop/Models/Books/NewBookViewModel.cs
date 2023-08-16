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
    }
}
