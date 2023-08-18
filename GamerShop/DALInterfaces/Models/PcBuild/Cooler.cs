namespace DALInterfaces.Models.PcBuild;

public class Cooler
{
    public string Model { get; set; }
    public string[] Socket { get; set; }
    public int DissipatedPower { get; set; }
    public int Height { get; set; }
}