namespace DALInterfaces.Models.PcBuild;

public class PSU : Component
{
    public string Model { get; set; }
    public int Power { get; set; }
    public string FormFactor { get; set; }
}