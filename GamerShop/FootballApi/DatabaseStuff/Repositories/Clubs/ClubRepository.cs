using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.DatabaseStuff.Repositories.Clubs
{
    public class ClubRepository : BaseRepository<Club>, IClubRepository
    {
        public ClubRepository(FootbalLApiContext context) : base(context)
        {
        }
        protected override IQueryable<Club> GetDbSetWithIncludeForPaginator()
        {
            return _context.Clubs
                   .Include(x => x.League);
        }
    }
}
