namespace GamerShop.Models.Users
{
	public class PaginatorUsersViewModel
	{
		public int Count { get; set; } // 37
		public int Page { get; set; }
		public List<int> AvailablePages { get; set; } = new List<int>(); // {1,2,3,4}
		public int PerPage { get; set; } // 10
		public List<UserViewModel> Users { get; set; }
	}
}
