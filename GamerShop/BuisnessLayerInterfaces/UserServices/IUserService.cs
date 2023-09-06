using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Users;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IUserService : IPaginatorServices<UserBlm>
    {
        bool IsUserNameExist(string name);
    }
}
