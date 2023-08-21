using DALInterfaces.Models;
using DALInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEfDB.Repositories
{
    public class RockMemberRepository : BaseRepository<RockMember>, IRockMemberRepository
    {
        public RockMemberRepository(WebContext context) : base(context)
        {
        }
    }
}
