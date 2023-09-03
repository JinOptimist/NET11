using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DALInterfaces.Models.RockHall
{
    public class RockMember : BaseModel
    {
        public string FullName { get; set; }
        public string Genre { get; set; }
        public int EntryYear { get; set; }
        public int YearOfBirth { get; set; }
        public int CreatorId { get; set; }
        public virtual RockBand? CurrentBand { get; set; }
    }
}
