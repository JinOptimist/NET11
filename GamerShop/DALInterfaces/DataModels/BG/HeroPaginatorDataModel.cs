using DALInterfaces.DataModels.PcBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.DataModels.BG
{
    public class HeroPaginatorDataModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<HeroDataModel> Heros { get; set; }
    }
}
