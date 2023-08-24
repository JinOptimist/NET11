namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public class BuildBlm : BaseBuildBlm
{ 
    //TODO Make full buildBlm model
    public string Label { get; set; } = null!;
    public int ProcessorId { get; set; }
    public string? GPUName { get; set; }
    public string? MainPhotoPath { get; set; }
    public decimal Price { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
}