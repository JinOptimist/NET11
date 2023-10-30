using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Users;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IUserService : IPaginatorServices<UserBlm>
    {
        List<string> GetAllUserNames();
        bool IsUserNameExist(string name);
    }
}
