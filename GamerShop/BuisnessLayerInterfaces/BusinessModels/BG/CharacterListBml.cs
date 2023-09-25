using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.BG
{
    public class CharacterListBml
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<BaldursGateBml> HeroList { get; set; }
    }
}
