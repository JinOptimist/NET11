using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Football;

namespace BusinessLayer.FootballServices
{
    public class FootballClubServices : IFootballServices<FootballClubBlm>
    {
        private IFootballClubRepository _footballClubRepository;
        private IUserRepository _userRepository;


        public FootballClubServices(IFootballClubRepository footballClubRepository, IUserRepository userRepository)
        {
            _footballClubRepository = footballClubRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<FootballClubBlm> GetAll()
         => _footballClubRepository
                .GetAll()
                .Select(x => new FootballClubBlm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stadium = x.Stadium,
                    Creator = new UserBlm { Name = _userRepository.Get(x.Creator).Name },
                });

        public void Save(FootballClubBlm footClub)
        {

            _footballClubRepository.Save(new FootballClub
            {
                Name = footClub.Name,
                Stadium = footClub.Stadium,
                Country = footClub.Country,
                Creator = footClub.Creator.Id
            });
        }

        public void Delete(int id)
        {
            _footballClubRepository.Remove(id);
        }

    }
}
