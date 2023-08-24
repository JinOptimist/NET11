using BusinessLayerInterfaces.BusinessModels.Users;

namespace BusinessLayerInterfaces.UserServices
{
	public interface IUserService
	{
		IndexBlm GetIndexBlm(int page, int perPage);
	}
}
