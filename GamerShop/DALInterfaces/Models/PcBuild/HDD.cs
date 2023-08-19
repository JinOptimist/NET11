namespace DALInterfaces.Models.PcBuild;

public class HDD : Component
{
    public string Model { get; set; } = null!;
    public int? Capacity { get; set; }
    public string? FormFactor { get; set; }
    public string? Interface { get; set; }
    public int? ReadingSpeed { get; set; }
    public int? WritingSpeed { get; set; }
}