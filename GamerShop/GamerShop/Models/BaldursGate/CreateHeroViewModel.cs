using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Models.BaldursGate
{
    public class CreateHeroViewModel
    {
        public int Id { get; set; }
        public IFormFile Avatar { get; set; }
        public List<SelectListItem> Class { get; set; }
        public List<SelectListItem> Race { get; set; }
        public List<SelectListItem> Subrace { get; set; }
        public List<SelectListItem> Origin { get; set; }
    }
}
