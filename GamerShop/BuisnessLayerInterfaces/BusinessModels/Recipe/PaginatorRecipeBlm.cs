namespace BusinessLayerInterfaces.BusinessModels.Recipe
{
	public class PaginatorRecipeBlm
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public int PerPage { get; set; }
		public List<RecipeBlm> Recipes { get; set; }
	}
}
