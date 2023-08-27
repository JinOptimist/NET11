namespace DALInterfaces.DataModels
{
	public class UserPaginatorDataModel
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public int PerPage { get; set; }
		public List<UserDataModel> Users { get; set; }
	}
}
