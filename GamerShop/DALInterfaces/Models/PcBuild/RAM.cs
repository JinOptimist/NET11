namespace DALInterfaces.Models.PcBuild;

public class RAM : Component
{
    public string Model { get; set; } = null!;
    public int? ModuleCount { get; set; }
    public int? KitCapacity { get; set; }
    public int? ModuleCapacity { get; set; }
    public int? Type { get; set; }
    public int? Frequency { get; set; }
}