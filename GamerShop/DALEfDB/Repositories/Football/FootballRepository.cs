using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class FootballRepository<T> : BaseRepository<T>, IFootballRepository<T> where T : BaseModel
    {
        public FootballRepository (WebContext context) : base(context) { }


    }
}
