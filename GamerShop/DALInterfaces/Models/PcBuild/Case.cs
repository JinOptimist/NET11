namespace DALInterfaces.Models.PcBuild;

public class Case : Component
{
    public string Model { get; set; } = null!;
    public string? Type { get; set; }
    public string? MaxMotherboardSize { get; set; }
    public int? MaxCPUCollerHeight { get; set; }
    public int? MaxGPULength { get; set; }
    public int? MaxPSULength { get; set; }
}