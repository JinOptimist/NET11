namespace DALInterfaces.Models.PcBuild;

public class Processor : Component
{
     public string ModelGroupe { get; set; } = null!;
     public string Model { get; set; } = null!;
     public string Socket { get; set; } = null!;
     public int? CoreCount { get; set; }
     public int? ThreadsCount { get; set; }
     public float? BaseFrequency { get; set; }
     public float? MaxFrequency { get; set; }
     public string? RAMSupporting { get; set; }
     public int? PCIEVersion { get; set; }
     public int? TDP { get; set; }
     public int? TechProcess { get; set; }
}