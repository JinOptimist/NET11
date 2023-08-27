using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;

namespace BusinessLayerInterfaces.BusinessModels.RockHall.RockBand
{
    public class RockBandGetBlm : BaseBandMemberBlm
    {
        public string CreatorName { get; set; }
    }
}
