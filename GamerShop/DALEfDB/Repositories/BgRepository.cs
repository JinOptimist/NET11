using DALInterfaces.Models;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories.BG;

namespace DALEfDB.Repositories
{
    public class BgRepository : BaseRepository<Heros>, IHeroRepository
    {
        public BgRepository(WebContext context) : base(context) { }
    }


}
