namespace DALInterfaces.Models.PcBuild;

public class Motherboard : Component
{
    public string Model { get; set; } = null!;
    public string? ProcessorType { get; set; }
    public string? Socket { get; set; }
    public string? Chipset { get; set; }
    public string? FormFactor { get; set; }
    public string? MemoryType { get; set; }
    public int? MemorySlotsCount { get; set; }
    public int? MaxMemoryCapacity { get; set; }
    public int? PCIEVersion { get; set; }
    public int? M2SlotsCount { get; set; }
}