using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Books
{
    public class EditBookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public List<SelectListItem>? Authors { get; set; }

        [Required]
        public IEnumerable<string> SelectedAuthors { get; set; }
    }
}
