using DALInterfaces.Models.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Repositories.RockHall
{
    public interface IRockBandRepository : IBaseRepository<RockBand>
    {
        void ChooseFavorite(int bandId, int memberId);
    }
}
