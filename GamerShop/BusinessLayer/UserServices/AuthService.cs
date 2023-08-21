using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.UserServices
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int? GetUserIdByNameAndPassword(string userName, string password)
        {
            return _userRepository.GetUserIdByNameAndPassword(userName, password);
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
        }

        public void Save(User user)
        {
            _userRepository.Save(user);
        }
    }
}
