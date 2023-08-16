using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.UserServices
{
    public class FootballSevices : IFootballServices
    {
        private IFootballClubRepository _footballClubRepository;

        public IEnumerable<FootballClubsBlm> GetAll()
         => _footballClubRepository
                .GetAll()
                .Select(x => new FootballClubsBlm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stadium = x.Stadium,
                });

        public void Save(FootballClubsBlm footClub)
        {
            _footballClubRepository.Save(new FootballClub
            {
                Name = footClub.Name,
                Stadium = footClub.Stadium,
                Country = footClub.Country,
            });
        }

        public void Delete(int id)
        {
           _footballClubRepository.Remove(id);
        }

    }
}
