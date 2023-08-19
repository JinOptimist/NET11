namespace DALInterfaces.Models.PcBuild;

public abstract class Component : BaseModel
{
    public string Manufacturer { get; set; } = null!;
    public DateOnly ProductionDate { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}