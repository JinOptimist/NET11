using DALInterfaces.Models;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories.BG;

namespace DALEfDB.Repositories.BG
{
    public class HeroRepository : BaseRepository<Heros>, IHeroRepository
    {
        public HeroRepository(WebContext context) : base(context) { }
    }


}
