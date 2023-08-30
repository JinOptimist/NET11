using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Models.RockHall
{
    public class RockMemberPaginatorDataModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<RockMember> RockMembers { get; set; }
    }
}
