namespace DALInterfaces.Models.PcBuild;

public abstract class Component : BaseModel
{
    public string? Manufacturer { get; set; }
    public string? ModelGroupe { get; set; }
    public string? Model { get; set; }
    public string FullName { get; set; }
    public DateTime? ProductionDate { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}