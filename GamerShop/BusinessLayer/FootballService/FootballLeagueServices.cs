using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.DataModels.Football;
using DALInterfaces.DataModels;
using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;

namespace BusinessLayer.FootballService
{
    public class FootballLeagueServices : IFootballServices<FootballLeagueBLM>
    {
        private IFootballLeagueRepository _footballLeagueRepository;
        private IUserRepository _userRepository;


        public FootballLeagueServices(IFootballLeagueRepository footballLeagueRepository, IUserRepository userRepository)
        {
            _footballLeagueRepository = footballLeagueRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<FootballLeagueBLM> GetAll()
         => _footballLeagueRepository
                .GetAll()
                .Select(x => new FootballLeagueBLM
                {
                    Id = x.Id,
                    FullName = x.Name,
                    ShortName = x.ShortName,
                    Country = x.Country,
                    Creator = new UserBlm { Id = x.UserCreator.Id, Name = x.UserCreator.Name }
                });

        public void Save(FootballLeagueBLM footLeague)
        {

            _footballLeagueRepository.Save(new FootballLeague
            {
                Name = footLeague.FullName,
                ShortName = footLeague.ShortName,
                Country = footLeague.Country,
                UserCreator = _userRepository.Get(footLeague.Creator.Id)
            });
        }

        public void Delete(int id)
        {
            _footballLeagueRepository.Remove(id);
        }

        public PaginatorBlm<FootballLeagueBLM> GetPaginatorBlm(int page, int perPage)
        {
            var data = _footballLeagueRepository.GetPaginatorDataModel(MapDataToShortDataModel, page, perPage);

            return new PaginatorBlm<FootballLeagueBLM>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(x => new FootballLeagueBLM
                {
                    Id = x.Id,
                    ShortName = x.ShortName,
                    Country = x.Country,
                    Creator = new UserBlm
                    {
                        Id = x.Creator.Id,
                        Name = x.Creator.Name,
                    },
                    FullName = x.FullName,
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
    }
}
