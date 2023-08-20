using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class BgRepository : BaseRepository<Hero>, IPersRepository
    {
        public BgRepository(WebContext context) : base(context) { }
    }


}
