using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.DataModels.Football;
using DALInterfaces.DataModels;
using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;
using BusinessLayerInterfaces.FootballServices.Dtos;
using System.Text.Json;
using System.Text;
using BusinessLayerInterfaces.Common.Dtos;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.FootballService
{
    public class FootballLeagueServices : IFootballLeagueServices
    {
        private IFootballLeagueRepository _footballLeagueRepository;
        private IUserRepository _userRepository;
        private string host;


        public FootballLeagueServices(IFootballLeagueRepository footballLeagueRepository, IUserRepository userRepository, IConfiguration config)
        {
            _footballLeagueRepository = footballLeagueRepository;
            _userRepository = userRepository;
            host = config.GetSection("Footballhost").Value;
        }

        public async Task<IEnumerable<FootballLeagueBLM>> GetAll()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{host}League/GetAll");
                var json = await response.Content.ReadAsStringAsync();
                var answwer = JsonSerializer.Deserialize<List<FootballLeagueDto>>(json);
                return answwer.Select(x => new FootballLeagueBLM
                {
                    Id = x.Id,
                    FullName = x.Name,
                    Country = x.Country,
                    ShortName = x.ShortName,
                    Creator = MapUserDalToBlm(_userRepository.Get(x.IdUserCreator))

                }).ToList();
            }
            catch
            {
                // Add to log that chat api is dead
                return null;
            }

        }
        public async Task Save(FootballLeagueBLM footLeague)
        {
            var leagueDto = new FootballLeagueDto
            {
                Id = footLeague.Id,
                Country = footLeague.Country,
                IdUserCreator = footLeague.Creator.Id,
                Name = footLeague.FullName,
                ShortName = footLeague.ShortName,
            };
            var httpClient = new HttpClient();
            var data = new StringContent(JsonSerializer.Serialize(leagueDto), Encoding.UTF8, "application/json");
            await httpClient.PostAsync($"{host}League/Save", data);
        }
        public async Task Delete(int id)
        {
            var httpClient = new HttpClient();
            await httpClient.DeleteAsync($"{host}League/Delete?id={id}");

        }

        public PaginatorBlm<FootballLeagueBLM> GetPaginatorBlm(int page, int perPage)
        {
            var data = GetDataForPaginator(page, perPage);

            return new PaginatorBlm<FootballLeagueBLM>
            {
                Count = data.Result.Count,
                Page = data.Result.Page,
                PerPage = data.Result.PerPage,
                Items = data.Result.Items.Select(x => new FootballLeagueBLM
                {
                    Id = x.Id,
                    ShortName = x.ShortName,
                    Country = x.Country,
                    Creator =  MapUserDalToBlm(_userRepository.Get(x.IdUserCreator)), 
                    FullName = x.Name
                }
                ).ToList()
            };
        }

        private ShortFootballLeagueDataModel MapDataToShortDataModel(FootballLeague footballLeague)
        {
            return new ShortFootballLeagueDataModel
            {
                Id = footballLeague.Id,
                ShortName = footballLeague.ShortName,
                Country = footballLeague.Country,
                Creator = new UserDataModel
                {
                    Id = footballLeague.UserCreator.Id,
                    Name = footballLeague.UserCreator.Name
                },
                FullName = footballLeague.Name
            }
             ;
        }

        public async Task<IEnumerable<ShortFootballLeagueBLM>> GetLimitedAmountLigues(int amount=1)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{host}League/GetLimitedAmount?amount={amount}");
            var json = await response.Content.ReadAsStringAsync();
            var answwer = JsonSerializer.Deserialize<List<ShortFootballLeagueDto>>(json);
            return answwer.Select(x => new ShortFootballLeagueBLM
            {
                Id= x.Id,
                ShortName = x.ShortName,
                
            }).ToList();

        }

        public async Task<int> Count()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{host}League/Count");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int>(json);
        }

        public async Task<IEnumerable<ShortFootballLeagueBLM>> Get(int skip, int count)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{host}League/Get?count={count}&skip={skip}");
            var json = await response.Content.ReadAsStringAsync();
            var answwer = JsonSerializer.Deserialize<List<ShortFootballLeagueDto>>(json);
            return answwer.Select(x => new ShortFootballLeagueBLM
            {
                Id = x.Id,
                ShortName = x.ShortName,
                
            }).ToList();
        }

        private async Task<PaginatorDto<FootballLeagueDto>> GetDataForPaginator(int page, int perPage)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{host}League/GetForPaginator?page={page}&perPage={perPage}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PaginatorDto<FootballLeagueDto>>(json);


        }
        private UserBlm MapUserDalToBlm(User user)
         => new UserBlm
         {
             Id = user.Id,
             Name = user.Name,
         };
    }
}
