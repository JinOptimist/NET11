using DALInterfaces.Models;

namespace BusinessLayerInterfaces.UserServices
{
    public interface IAuthService
    {
        int? GetUserIdByNameAndPassword(string userName, string password);
        void Save(User user);
        void Remove(int id);
    }
}
