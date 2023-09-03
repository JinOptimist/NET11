using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEfDB.Repositories.RockHall
{
    public class RockMemberRepository : BaseRepository<RockMember>, IRockMemberRepository
    {
        public RockMemberRepository(WebContext context) : base(context)
        {
        }

        
    }
}
