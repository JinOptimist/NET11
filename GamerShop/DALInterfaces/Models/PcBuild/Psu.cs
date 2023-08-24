namespace DALInterfaces.Models.PcBuild;

public class Psu : Component
{
    public int Power { get; set; } 
    public string? FormFactor { get; set; }
    
    public virtual ICollection<Build> Builds { get; set; }
}