using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamerShop.Models.RockHall
{
    public class InfoBandViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CreatorName { get; set; }
    }
}
