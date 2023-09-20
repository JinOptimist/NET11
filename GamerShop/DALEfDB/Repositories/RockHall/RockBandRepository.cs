using DALInterfaces.Models;
using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

