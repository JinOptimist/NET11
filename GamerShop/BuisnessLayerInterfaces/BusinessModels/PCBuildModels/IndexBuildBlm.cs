namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public class IndexBuildBlm 
{
    public int Count { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public List<ShortBuildBlm> Builds { get; set; }
}