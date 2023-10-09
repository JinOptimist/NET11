using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamerShop.Models.RockHall
{
    public class ChooseBandGetViewModel
    {
        public List<SelectListItem> AllBandsSelectListItem { get; set; }
        public List<SelectListItem> AllMembersSelectListItem { get; set; }

    }
}
