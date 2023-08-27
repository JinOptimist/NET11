namespace GamerShop.Models.Recipe
{
	public class PaginatorRecipeViewModel
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public List<int> AvailablePages { get; set; } = new List<int>();
		public int PerPage { get; set; } // 10
		public List<ShowRecipeViewModel> Recipes { get; set; }
	}
}
