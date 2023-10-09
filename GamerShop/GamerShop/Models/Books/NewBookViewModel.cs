using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Books
{
    public class NewBookViewModel
    {
        [Required]
        public string Name { get; set; }
        public int YearOfIssue { get; set; }

        [Required]
        public List<SelectListItem> Authors { get; set; }
    }
}
