using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
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
                });

        public void Save(FootballLeagueBLM footLeague)
        {

            _footballLeagueRepository.Save(new FootballLeague
            {
                Name = footLeague.FullName,
                ShortName = footLeague.ShortName,
                Country = footLeague.Country,
            });
        }

        public void Delete(int id)
        {
            _footballLeagueRepository.Remove(id);
        }


    }
}
