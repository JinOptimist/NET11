namespace DALInterfaces.Models.Recipe
{
	public class Review : BaseModel
	{
		public virtual Recipe Recipe { get; set; }

		public virtual User User { get; set; }

		public double Rating { get; set; }

		public string ReviewText { get; set; }

		public DateTime ReviewDate { get; set; }
	}
}
