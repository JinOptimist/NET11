using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class FootballClubRepository : BaseRepository<FootballClub>, IFootballClubRepository
    {
        public FootballClubRepository(WebContext context) : base(context) { }


    }
}
