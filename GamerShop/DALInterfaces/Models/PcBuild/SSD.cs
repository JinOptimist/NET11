namespace DALInterfaces.Models.PcBuild;

public class SSD : Component
{
    public string Model { get; set; }
    public int Capacity { get; set; }
    public string FormFactor { get; set; }
    public string Interface { get; set; }
    public int Size { get; set; }
    public int ReadingSpeed { get; set; }
    public int WritingSpeed { get; set; }
}