namespace DALInterfaces.Models.Recipe
{
	public class Review : BaseModel
	{
		public int RecipeId { get; set; }

		public int UserId { get; set; }

		public double Rating { get; set; }

		public string ReviewText { get; set; }

		public DateTime ReviewDate { get; set; }
	}
}
