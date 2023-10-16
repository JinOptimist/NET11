using System.Collections;

namespace GamerShop.Models
{
    public class PaginatorViewModel<ViewModelTemplate>
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<int> AvailablePages { get; set; } = new List<int>();
        public int PerPage { get; set; }

        public List<ViewModelTemplate> Items { get; set; }
        public List<FilterViewModel> Filters { get; set; }
    }
}
