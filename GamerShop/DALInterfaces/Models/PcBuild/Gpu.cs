namespace DALInterfaces.Models.PcBuild;

public class Gpu : Component
{
    public int? PciExpressVersion { get; set; }
    public string? Chip { get; set; }
    public float? BaseFrequency { get; set; }
    public float? MaxFrequency { get; set; }
    public string? MemoryType { get; set; }
    public int? MemoryBusWidth { get; set; }
    public string? DirectXSupport { get; set; }
    public string? PowerConnectors { get; set; }
    public int? PowerConsumption { get; set; }
    public int? RecommendedPsuPowerConsumption { get; set; }

    public virtual ICollection<Build> Builds { get; set; }
}