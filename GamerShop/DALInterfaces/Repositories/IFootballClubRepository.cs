using DALInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Repositories
{
    public interface IFootballClubRepository
    {
        IEnumerable<FootballClub> GetAll();
        void Save(FootballClub footballClub);
        void Remove(string id);
    }
}
