namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public class NewBuildBlm
{
    public int CreatorId { get; set; }
    public int ProcessorId { get; set; }
    public int MotherboardId { get; set; }
    public int GpuId { get; set; }
    public int CurrentCaseId { get; set; }
    public int CoolerId { get; set; }
    public int HddId { get; set; }
    public int SsdId { get; set; }
    public int RamId { get; set; }
    public int PsuId { get; set; }
    public int RamCount { get; set; }
    public int? SsdCount { get; set; }
    public int? HddCount { get; set; }
    public int? GpuCount { get; set; }
    public int Price { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? MainPhotoPath { get; set; }
}