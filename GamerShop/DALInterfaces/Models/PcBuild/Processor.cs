namespace DALInterfaces.Models.PcBuild;

public class Processor : Component
{
     public string Socket { get; set; } = null!;
     public int? CoreCount { get; set; }
     public int? ThreadsCount { get; set; }
     public float? BaseFrequency { get; set; }
     public float? MaxFrequency { get; set; }
     public string? RamSupporting { get; set; }
     public int? PciExVersion { get; set; }
     public int? Tdp { get; set; }
     public int? TechProcess { get; set; }

     public virtual ICollection<Build> Builds { get; set; }
}