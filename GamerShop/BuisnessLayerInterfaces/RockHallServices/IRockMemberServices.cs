using BusinessLayerInterfaces.BusinessModels.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.RockHallServices
{
    public interface IRockMemberServices
    {
        IEnumerable<RockMemberGetBlm> GetAll();

        void Remove(int id);

        void Save(RockMemberPostBlm rockMemberBlm);
    }
}
