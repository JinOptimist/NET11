namespace DALInterfaces.DataModels.Recipe
{
	public class PaginatorRecipeDataModel
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public int PerPage { get; set; }
		public List<RecipeDataModel> Recipes { get; set; }
	}
}
