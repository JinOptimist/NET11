namespace DALInterfaces.Models.Recipe
{
	public class FavoriteRecipe : BaseModel
	{
		public virtual int UserId { get; set; }

		public virtual int RecipeId { get; set; }
	}
}
