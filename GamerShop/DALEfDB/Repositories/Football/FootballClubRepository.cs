using DALInterfaces.Models;
using DALInterfaces.Models.Football;
using DALInterfaces.Repositories.Football;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB.Repositories.Football
{
    public class FootballClubRepository : BaseRepository<FootballClub>, IFootballClubRepository
    {
        public FootballClubRepository(WebContext context) : base(context) { }

        protected override IQueryable<FootballClub> GetDbSetWithIncludeForPaginator()
        {
            return _context.FootballClubs
                .Include(x => x.UserCreator)
                .Include(x=>x.League);
        }

    }
}
