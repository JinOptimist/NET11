using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
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


        public FootballClubServices(IFootballClubRepository footballClubRepository, IUserRepository userRepository,IFootballLeagueRepository footballLeagueRepository)
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
                    Creator = new UserBlm { Name =  x.UserCreator.Name},
                    ShortFootballLeagueInfo = new ShortFootballLeagueBLM {Id =x.League.Id , ShortName = x.League.ShortName }
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

    }
}
