using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.BG
{
    public class NewBGBml
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int RaceId { get; set; }
        public int SubraceId { get; set; }
        public int OriginId { get; set; }
        public int Bone { get; set; }
    }
}
