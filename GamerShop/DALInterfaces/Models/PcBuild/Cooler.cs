namespace DALInterfaces.Models.PcBuild;

public class Cooler : Component
{
    public string? Socket { get; set; } //TODO Sockets
    public int? DissipatedPower { get; set; }
    public int? Height { get; set; }
    
    public virtual ICollection<Build> Builds { get; set; }
}