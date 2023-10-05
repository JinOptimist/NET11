using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB.Repositories.RockHall
{
    public class RockMemberRepository : BaseRepository<RockMember>, IRockMemberRepository
    {
        public RockMemberRepository(WebContext context) : base(context)
        {
        }

        protected override IQueryable<RockMember> GetDbSetWithIncludeForPaginator()
        {
            return _context.RockMembers.Include(x => x.CurrentBand);
        }


    }
}
