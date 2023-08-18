namespace DALInterfaces.Models.PcBuild;

public class Processor : Component
{
     public string ModelGroupe { get; set; }
     public string Model { get; set; }
     public string Socket { get; set; }
     public int CoreCount { get; set; }
     public int ThreadsCount { get; set; }
     public float BaseFrequency { get; set; }
     public float MaxFrequency { get; set; }
     public string RAMSupporting { get; set; }
     public string PCIEVersion { get; set; }
     public int TDP { get; set; }
     public int TechProcess { get; set; }
}