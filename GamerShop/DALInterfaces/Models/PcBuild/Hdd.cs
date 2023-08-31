namespace DALInterfaces.Models.PcBuild;

public class Hdd : Component
{
    public int? Capacity { get; set; }
    public string? FormFactor { get; set; }
    public string? Interface { get; set; }
    public int? ReadingSpeed { get; set; }
    public int? WritingSpeed { get; set; }
    
    public virtual ICollection<Build> Builds { get; set; }
}