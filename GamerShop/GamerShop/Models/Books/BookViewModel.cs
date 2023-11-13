using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Models.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public List<SelectListItem> Authors { get; set; }
    }
}
