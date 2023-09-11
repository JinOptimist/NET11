using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.RockHall.RockBand
{
    public class RockBandPostBlm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CreatorId { get; set; }
    }
}
