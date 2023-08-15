using DALInterfaces.Models;
using DALInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWrongDB.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
    }
}
