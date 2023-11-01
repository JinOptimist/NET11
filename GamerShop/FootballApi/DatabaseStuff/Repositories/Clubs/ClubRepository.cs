using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Base;

namespace FootballApi.DatabaseStuff.Repositories.Clubs
{
    public class ClubRepository : BaseRepository<Club>, IClubRepository
    {
        public ClubRepository(FootbalLApiContext context) : base(context)
        {
        }
    }
}
