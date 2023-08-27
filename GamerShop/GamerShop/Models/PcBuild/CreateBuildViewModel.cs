using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Models.PcBuild;

public class CreateBuildViewModel
{
    public List<SelectListItem> Processors { get; set; }
    public List<SelectListItem> Motherboards { get; set; }
    public List<SelectListItem> Rams { get; set; }
    public List<SelectListItem> Cases { get; set; }
    public List<SelectListItem> Ssds { get; set; }
    public List<SelectListItem> Hdds { get; set; }
    public List<SelectListItem> Coolers { get; set; }
    public List<SelectListItem> Gpus { get; set; }
    public List<SelectListItem> Psus { get; set; }
    public List<SelectListItem> ComponentCount { get; set; } = new List<SelectListItem>()
    {
        new SelectListItem() {Text = "x1", Value = "1"},
        new SelectListItem() {Text = "x2", Value = "2"},
        new SelectListItem() {Text = "x3", Value = "3"},
        new SelectListItem() {Text = "x4", Value = "4"},
    };
}