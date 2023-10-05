using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;

namespace DALEfDB.Repositories.RockHall
{
    public class RockBandRepository : BaseRepository<RockBand>, IRockBandRepository
    {
        public RockBandRepository(WebContext context) : base(context)
        {
        }

        public override void Remove(int id)
        {
            var band = _dbSet.First(x => x.Id == id);
            band
                .MembersOfTheGroup
                .ToList()
                .ForEach(x => band.MembersOfTheGroup.Remove(x));

            base.Remove(id);
        }

        public void ChooseMember(int bandId, int memberId)
        {
            var band = _dbSet.First(x => x.Id == bandId);
            var member = _context.RockMembers.First(x => x.Id == memberId);
            band.MembersOfTheGroup.Add(member);
            _context.SaveChanges();
        }
    }
}

