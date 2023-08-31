using DALInterfaces.Models.Football;
using DALInterfaces.Repositories.Football;

namespace DALEfDB.Repositories.Football
{
    public class FootballClubRepository : BaseRepository<FootballClub>, IFootballClubRepository
    {
        public FootballClubRepository(WebContext context) : base(context) { }


    }
}
