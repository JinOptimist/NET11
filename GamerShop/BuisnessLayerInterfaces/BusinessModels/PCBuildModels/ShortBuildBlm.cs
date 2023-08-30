namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public class ShortBuildBlm : BaseBuildBlm
{
    public string ProcessorName { get; set; }
    public string? GpuName { get; set; }
    public string? PhotoPath { get; set; }
}