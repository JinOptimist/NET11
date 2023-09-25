using GamerShop.Models.PcBuild;

namespace GamerShop.Models.BaldursGate
{
    public class PaginatorHeroViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<int> AvailablePages { get; set; } = new List<int>();
        public List<HeroListViewModel> HeroList { get; set; }

    }
}
