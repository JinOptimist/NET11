using GamerShop.Models.Users;

namespace GamerShop.Models.RockHall
{
    public class PaginatorRockMemberViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<int> AvailablePages { get; set; } = new List<int>();
        public int PerPage { get; set; }
        public List<InfoMemberViewModel> RockMembers { get; set; }
    }
}
