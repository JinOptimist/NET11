using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.DataModels;
using DALInterfaces.DataModels.Football;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;

namespace BusinessLayer.FootballServices
{
    public class FootballClubServices : IFootballServices<FootballClubBlm>
    {
        private IFootballClubRepository _footballClubRepository;
        private IUserRepository _userRepository;
        private IFootballLeagueRepository _footballLeagueRepository;


        public FootballClubServices(IFootballClubRepository footballClubRepository, IUserRepository userRepository, IFootballLeagueRepository footballLeagueRepository)
        {
            _footballClubRepository = footballClubRepository;
            _userRepository = userRepository;
            _footballLeagueRepository = footballLeagueRepository;
        }

        public IEnumerable<FootballClubBlm> GetAll()
         => _footballClubRepository
                .GetAll()
                .Select(x => new FootballClubBlm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stadium = x.Stadium,
                    Creator = new UserBlm { Name = x.UserCreator.Name },
                    ShortFootballLeagueInfo = new ShortFootballLeagueBLM { Id = x.League.Id, ShortName = x.League.ShortName }
                });

        public void Save(FootballClubBlm footClub)
        {

            _footballClubRepository.Save(new FootballClub
            {
                Name = footClub.Name,
                Stadium = footClub.Stadium,
                League = _footballLeagueRepository.Get(footClub.ShortFootballLeagueInfo.Id),
                UserCreator = _userRepository.Get(footClub.Id)
            });
        }

        public void Delete(int id)
        {
            _footballClubRepository.Remove(id);
        }

        public PaginatorBlm<FootballClubBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _footballClubRepository.GetPaginatorDataModel(MapDataToShortDataModel, page, perPage);

            return new PaginatorBlm<FootballClubBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(x => new FootballClubBlm
                {
                    Name = x.Name,
                    Stadium = x.Stadium,
                    Id = x.id,
                    Creator = new UserBlm
                    {
                        Id = x.UserCreator.Id,
                        Name = x.UserCreator.Name
                    },
                    ShortFootballLeagueInfo = new ShortFootballLeagueBLM
                    {
                        Id = x.League.Id,
                        ShortName = x.League.ShortName,
                    }

                }).ToList()
            };
        }

        private FootClubDataModel MapDataToShortDataModel(FootballClub dbFootballClub)
        {
            return new FootClubDataModel
            {
                id = dbFootballClub.Id,
                Name = dbFootballClub.Name,
                Stadium = dbFootballClub.Stadium,
                UserCreator = new UserDataModel
                {
                    Id = dbFootballClub.UserCreator.Id,
                    Name = dbFootballClub.UserCreator.Name,
                    Birthday = dbFootballClub.UserCreator.Birthday
                },
                League = new ShortFootballLeagueDataModel 
                {
                Id = dbFootballClub.League.Id,
                Country = dbFootballClub.League.Country,
                ShortName = dbFootballClub.League.ShortName,
                }
   
            };
        }
    }
}