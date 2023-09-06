using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.UserServices
{
	public interface IHomeServices
	{
        IEnumerable<UserBlm> GetLastLoginUsers();

		UserBlm GetUserById(int id);

		IEnumerable<UserBlm> GetUsersBySearchString(string search, int count = 5);
	}
}
