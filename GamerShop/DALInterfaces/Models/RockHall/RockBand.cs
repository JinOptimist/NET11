using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.Models.RockHall
{
    public class RockBand : BaseModel
    {
        public string FullName { get; set; }
        public int CreatorId { get; set; }
        public  virtual ICollection<RockMember> MembersOfTheGroup { get; set; }
    }
}
