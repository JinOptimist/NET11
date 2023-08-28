using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Users;
using BusinessLayerInterfaces.Common;
using BusinessLayerInterfaces.UserServices;
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

		public IndexBlm GetIndexBlm(int page, int perPage)
		{
			var data = _userRepository.GetUserPaginatorDataModel(page, perPage);
			return new IndexBlm
			{
				Count = data.Count,
				Page = data.Page,
				PerPage = data.PerPage,
				Users = data.Users.Select(userDataModel => new UserBlm
				{
					Id = userDataModel.Id,
					Name = userDataModel.Name,
					AgeInDays = (DateTime.Now - userDataModel.Birthday).Days,
					FavoriteMovieName = userDataModel.FavoriteMovieName ?? "---"
				}).ToList()
			};
		}

        public PaginatorBlm<UserBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _userRepository.GetUserPaginatorDataModel(page, perPage);
            return new PaginatorBlm<UserBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Users.Select(userDataModel => new UserBlm
                {
                    Id = userDataModel.Id,
                    Name = userDataModel.Name,
                    AgeInDays = (DateTime.Now - userDataModel.Birthday).Days,
                    FavoriteMovieName = userDataModel.FavoriteMovieName ?? "---"
                }).ToList()
            };
        }
    }
}
