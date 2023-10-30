using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using BusinessLayerInterfaces.UserServices.Dtos;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using System.Text.Json;

namespace BusinessLayer.UserServices
{
	public class HomeServices : IHomeServices
	{
		private IUserRepository _userRepository;

		public HomeServices(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<UserBlm> GetLastLoginUsers()
			=> _userRepository
				.GetAll()
				.Take(5)
				.Select(Map);

		public UserBlm GetUserById(int id)
		{
			var userDb = _userRepository.Get(id);
			return new UserBlm
			{
				Id = userDb.Id,
				Name = userDb.Name,
			};
		}

		public IEnumerable<UserBlm> GetUsersBySearchString(string search, int count = 5)
			=> _userRepository
				.GetUsersBySearchString(search, count)
				.Select(Map);

		private UserBlm Map(User user)
		{
			return new UserBlm
			{
				Id = user.Id,
				Name = user.Name,
				FavoriteMovieName = user.FavoriteMovie?.Title ?? "---"
			};
		}

		public async Task<IEnumerable<MessageDto>> GetLastMessagesAsync()
		{
			try
			{
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:7250/getMessages");
                var json = await response.Content.ReadAsStringAsync();
                var messages = JsonSerializer.Deserialize<List<MessageDto>>(json);
                return messages;
            }
			catch
			{
				// Add to log that chat api is dead
				return null;
			}
        }
	}
}
