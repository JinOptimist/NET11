using DALInterfaces.Models;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class BgRepository : BaseRepository<Heros>, IHeroRepository
    {
        public BgRepository(WebContext context) : base(context) { }
    }


}
