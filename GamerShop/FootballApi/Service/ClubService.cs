using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Clubs;

namespace FootballApi.Service
{
    public class ClubService : IClubService
    {
        private IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;

        }

        public IEnumerable<Club> GetClubs()
        {

            return _clubRepository.GetAll();
            
        }
    }
}
