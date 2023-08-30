using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.BusinessModels.RockHall.RockMember
{
    public class RockMemberPaginatorBlm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<RockMemberGetBlm> RockMembers { get; set; }
    }
}
