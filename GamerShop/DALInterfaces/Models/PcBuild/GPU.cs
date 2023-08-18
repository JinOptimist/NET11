namespace DALInterfaces.Models.PcBuild;

public class GPU : Component
{
    public string? ModelGroupe { get; set; }
    public string Model { get; set; }
    public int PCIEVersion { get; set; }
    public string Chip { get; set; }
    public float BaseFrequency { get; set; }
    public float MaxFrequency { get; set; }
    public string MemoryType { get; set; }
    public int MemoryBusWidth { get; set; }
    public string DirectXSupport { get; set; }
    public string PowerConnectors { get; set; }
    public int PowerConsumption { get; set; }
    public int RecomendedPSUPowerConsumption { get; set; }
}