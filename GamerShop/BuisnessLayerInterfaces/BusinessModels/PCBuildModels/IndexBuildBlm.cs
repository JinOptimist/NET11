namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public class IndexBuildBlm : BaseBuildBlm
{
    public string Label { get; set; } = null!;
    public string ProcessorName { get; set; } = null!;
    public List<string> GPUsNames { get; set; } = null!;
    public string? MainPhotoPath { get; set; }
    public string Price { get; set; }
    public string UserName { get; set; }
    public string Rating { get; set; }
}