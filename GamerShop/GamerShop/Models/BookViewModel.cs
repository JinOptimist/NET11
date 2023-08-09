using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models
{
    public class BookViewModel
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
    }
}
