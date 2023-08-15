using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.UserServices
{
	public interface IHomeServices
	{
        IEnumerable<UserBlm> GetLastLoginUsers();

		UserBlm GetUserById(int id);
	}
}
