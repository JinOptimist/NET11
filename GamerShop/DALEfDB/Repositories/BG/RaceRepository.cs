using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories.BG;

namespace DALEfDB.Repositories.BG
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        public RaceRepository(WebContext context) : base(context)
        {

        }
    }
}
