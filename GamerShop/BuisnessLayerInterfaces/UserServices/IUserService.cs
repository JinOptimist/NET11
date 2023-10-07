using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Users;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IUserService : IPaginatorServices<UserBlm, User>
    {
        List<string> GetAllUserNames();
        bool IsUserNameExist(string name);
    }
}
