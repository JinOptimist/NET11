using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.BG
{
    public class AllAtributeForAddingBml
    {
        public IEnumerable<BaseAtributeBml> Class { get; set; }
        public IEnumerable<BaseAtributeBml> Race { get; set; }
        public IEnumerable<BaseAtributeBml> Subrace { get; set; }
        public IEnumerable<BaseAtributeBml> Origin { get; set; }
    }
}
