namespace DALInterfaces.Models.PcBuild;

public class Case : Component
{
    public string? Type { get; set; }
    public string? MaxMotherboardSize { get; set; }
    public int? MaxCpuCollerHeight { get; set; }
    public int? MaxGpuLength { get; set; }
    public int? MaxPsuLength { get; set; }
    
    public virtual ICollection<Build> Builds { get; set; }
}