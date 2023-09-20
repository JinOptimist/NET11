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
        void ChooseMember(int bandId, int memberId);
    }
}
