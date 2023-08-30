namespace GamerShop.Models.PcBuild;

public class PaginatorBuildsViewModel
{
    public int Count { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public List<int> AvailablePages { get; set; } = new List<int>();
    public List<BuildsIndexViewModel> Builds { get; set; }
}