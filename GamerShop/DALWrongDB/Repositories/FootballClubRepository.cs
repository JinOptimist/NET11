
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{

    public class FootballClubRepository : IFootballClubRepository
    {
        private static List<FootballClub> _footballClubs = new List<FootballClub>();

       public IEnumerable<FootballClub> GetAll()
        {
            return _footballClubs;
        }

        public void  Save(FootballClub footballClub)
        {
        _footballClubs.Add(footballClub);
        }

        public void Remove(string id)
        {
            _footballClubs.Remove(_footballClubs[Convert.ToInt32(id)]);
        }

    }
}
