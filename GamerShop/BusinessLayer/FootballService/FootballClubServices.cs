using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using BusinessLayerInterfaces.Common.Dtos;
using BusinessLayerInterfaces.FootballService;
using BusinessLayerInterfaces.FootballServices.Dtos;
using DALInterfaces.Models;
using DALInterfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text;
using System.Text.Json;

namespace BusinessLayer.FootballServices
{
    public class FootballClubServices : IFootballClubService
    {
        private IUserRepository _userRepository;
        private string host;

        public FootballClubServices(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            host = config.GetSection("Footballhost").Value;
        }

        public async Task<IEnumerable<FootballClubBlm>> GetAll()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{host}GetAll");
                var json = await response.Content.ReadAsStringAsync();
                var answwer = JsonSerializer.Deserialize<List<FootballClubDto>>(json);
                return answwer.Select(x => new FootballClubBlm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stadium = x.Stadium,
                    Creator = MapUserDalToBlm(_userRepository.Get(x.IdUserCreator)),
                    ShortFootballLeagueInfo = new ShortFootballLeagueBLM
                    {
                        Id = x.League.Id,
                        ShortName = x.League.ShortName,
                    }

                }).ToList();
            }
            catch
            {
                // Add to log that chat api is dead
                return null;
            }
        }

        public async Task Save(FootballClubBlm footClub)
        {
            var clubDto = new FootballClubDto
            {
                Id = footClub.Id,
                Name = footClub.Name,
                Stadium = footClub.Stadium,
                IdUserCreator = footClub.Creator.Id,
                League = new ShortFootballLeagueDto
                {
                    Id = footClub.ShortFootballLeagueInfo.Id,
                    ShortName = footClub.ShortFootballLeagueInfo.ShortName
                }
            };
                 
                var httpClient = new HttpClient();
                var data = new StringContent(JsonSerializer.Serialize(clubDto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{host}Save", data);
            
              
        }

        public async Task Delete(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"{host}Remove?id={id}");
        }

        public async Task<PaginatorDto<FootballClubDto>> GetDataForPaginator(int page, int perPage)
        {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{host}GetClubsForPaginator?page={page}&perPage={perPage}");
                var json = await response.Content.ReadAsStringAsync();
                var answer = JsonSerializer.Deserialize<PaginatorDto<FootballClubDto>>(json);
                return answer;
          
        }

        private UserBlm MapUserDalToBlm(User user)
        => new UserBlm
        {
            Id = user.Id,
            Name = user.Name,
        };
        private FootballClubBlm MapToBlm(FootballClubDto footballClubDto)
        => new FootballClubBlm
        {
            Id = footballClubDto.Id,
            Name = footballClubDto.Name,
            Stadium = footballClubDto.Stadium,
            Creator = MapUserDalToBlm(_userRepository.Get(footballClubDto.IdUserCreator)),
            ShortFootballLeagueInfo = new ShortFootballLeagueBLM
            {
                Id = footballClubDto.League.Id,
                ShortName = footballClubDto.League.ShortName,
            }

        };

        PaginatorBlm<FootballClubBlm> IPaginatorServices<FootballClubBlm>.GetPaginatorBlm(int page, int perPage)
        {
            var data = GetDataForPaginator(page, perPage);

             var paginator = new PaginatorBlm<FootballClubBlm>
            {
                Count = data.Result.Count,
                Page = data.Result.Page,
                PerPage = data.Result.PerPage,
                Items = data.Result.Items.Select(x => MapToBlm(x)).ToList(),

             };
            return paginator;
        }
    }
}