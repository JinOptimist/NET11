using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces.DataModels.BG;
using DALInterfaces.Models;
using DALInterfaces.Models.BG;

namespace DALInterfaces.Repositories.BG
{
    public interface IHeroRepository : IBaseRepository<Heros>
    {
        HeroPaginatorDataModel GetHeroPaginatorDataModel(int page,int perPage);
    }
}
