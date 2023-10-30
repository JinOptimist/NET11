using BusinessLayerInterfaces.BusinessModels;

namespace GamerShop.Services
{
	public interface IAuthService
	{
		UserBlm GetCurrentUser();

		string GetAvatar();

		string GetIdStr();

		string GetUserName();
    }
}