using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories.BG;

namespace DALEfDB.Repositories.BG
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(WebContext context) : base(context)
        {

        }
    }
}
