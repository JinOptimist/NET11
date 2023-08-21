using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.FootballService;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.FootballServices
{
    public class FootballSevices : IFootballServices
    {
        private IFootballClubRepository _footballClubRepository;
        private IUserRepository _userRepository;


        public FootballSevices(IFootballClubRepository footballClubRepository, IUserRepository userRepository)
        {
            _footballClubRepository = footballClubRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<FootballClubsBlm> GetAll()
         => _footballClubRepository
                .GetAll()
                .Select(x => new FootballClubsBlm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stadium = x.Stadium,
                    Creator = new UserBlm { Name = _userRepository.Get(x.Creator).Name },
                });

        public void Save(FootballClubsBlm footClub)
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
