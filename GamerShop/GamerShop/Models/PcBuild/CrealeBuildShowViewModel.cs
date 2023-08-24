using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Models.PcBuild;

public class CrealeBuildShowViewModel
{
    public IEnumerable<ComponentBlm> Processors { get; set; }
    public IEnumerable<ComponentBlm> Motherboards { get; set; }
    public IEnumerable<ComponentBlm> Rams { get; set; }
    public IEnumerable<ComponentBlm> Cases { get; set; }
    public IEnumerable<ComponentBlm> Ssds { get; set; }
    public IEnumerable<ComponentBlm> Hdds { get; set; }
    public IEnumerable<ComponentBlm> Coolers { get; set; }
    public IEnumerable<ComponentBlm> Gpus { get; set; }

    public IEnumerable<ComponentBlm> Psus { get; set; }
}