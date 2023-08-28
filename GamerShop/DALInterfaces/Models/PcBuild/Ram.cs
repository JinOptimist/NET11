namespace DALInterfaces.Models.PcBuild;

public class Ram : Component
{
    public int? ModuleCount { get; set; }
    public int? KitCapacity { get; set; }
    public int? ModuleCapacity { get; set; }
    public string? Type { get; set; }
    public int? Frequency { get; set; }
    
    public virtual ICollection<Build> Builds { get; set; }
}