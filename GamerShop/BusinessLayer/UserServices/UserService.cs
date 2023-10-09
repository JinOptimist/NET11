using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.DataModels;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.UserServices
{
    public class UserService : IUserService
    {
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

        public List<string> GetAllUserNames()
        {
            return _userRepository.GetAll().Select(x => x.Name).ToList();
        }

        public PaginatorBlm<UserBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _userRepository.GetPaginatorDataModel(MapUserToUserDataModel, page, perPage);

            return new PaginatorBlm<UserBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(userDataModel => new UserBlm
                {
                    Id = userDataModel.Id,
                    Name = userDataModel.Name,
                    AgeInDays = (DateTime.Now - userDataModel.Birthday).Days,
                    FavoriteMovieName = userDataModel.FavoriteMovieName ?? "---"
                }).ToList()
            };
        }

        public bool IsUserNameExist(string name)
            => _userRepository.IsUserNameExist(name);

        private UserDataModel MapUserToUserDataModel(User dbUser)
		{
            return new UserDataModel
            {
                Id = dbUser.Id,
                Name = dbUser.Name,
                Birthday = dbUser.Birthday,
                FavoriteMovieName = dbUser.FavoriteMovie == null ? null : dbUser.FavoriteMovie.Title
            };
        }
    }
}
