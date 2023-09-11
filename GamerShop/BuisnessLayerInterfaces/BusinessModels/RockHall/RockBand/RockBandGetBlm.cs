using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;

namespace BusinessLayerInterfaces.BusinessModels.RockHall.RockBand
{
    public class RockBandGetBlm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CreatorName { get; set; }
    }
}
