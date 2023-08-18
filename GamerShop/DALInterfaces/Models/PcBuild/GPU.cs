namespace DALInterfaces.Models.PcBuild;

public class GPU : Component
{
    public string? ModelGroupe { get; set; }
    public string Model { get; set; }
    public string PCIEVersion { get; set; }
    public string Chip { get; set; }
    
}