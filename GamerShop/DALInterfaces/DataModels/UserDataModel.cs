namespace DALInterfaces.DataModels
{
	public class UserDataModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public string? FavoriteMovieName { get; set; }
	}
}
