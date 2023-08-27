using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamerShop.Models.RockHall
{
    public class InfoMemberViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Genre { get; set; }
        public int EntryYear { get; set; }
        public int YearOfBirth { get; set; }
        public string CreatorName { get; set; }
    }
}
