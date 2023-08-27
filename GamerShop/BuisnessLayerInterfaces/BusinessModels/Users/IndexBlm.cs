namespace BusinessLayerInterfaces.BusinessModels.Users
{
	public class IndexBlm
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public int PerPage { get; set; }
		public List<UserBlm> Users { get; set; }
	}
}
