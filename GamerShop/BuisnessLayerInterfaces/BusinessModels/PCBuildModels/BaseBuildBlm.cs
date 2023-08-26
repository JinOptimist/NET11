namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public abstract class BaseBuildBlm
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string DateOfCreate { get; set; }
    public int CreatorId { get; set; }
    public string CreatorName { get; set; }
    public string Price { get; set; }
    public int Rating { get; set; }
}