using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.FootballService
{
    public class FootballLegueServices : IFootballServices<FootballLeagueBlm>
    {
        private IFootballRepository<FootballLegue> _footballLegueRepository;
        private IUserRepository _userRepository;


        public FootballLegueServices(IFootballRepository<FootballLegue> footballLegueRepository, IUserRepository userRepository)
        {
            _footballLegueRepository = footballLegueRepository;
            _userRepository = userRepository;
        }
        public void Delete(int id)
        {
            _footballLegueRepository.Remove(id);
        }

        public IEnumerable<FootballLeagueBlm> GetAll()
                => _footballLegueRepository
                .GetAll()
                .Select(x => new FootballLeagueBlm
                {
                    Id = x.Id,
                    Country = x.Country,
                    FullName = x.FullName,
                    ShortName = x.ShortName
                });

        public void Save(FootballLeagueBlm footballBlM)
        {
            _footballLegueRepository.Save(new FootballLegue
            {
                Country = footballBlM.Country,
                FullName = footballBlM.FullName,
                ShortName = footballBlM.ShortName
            });
        }
    }
}
