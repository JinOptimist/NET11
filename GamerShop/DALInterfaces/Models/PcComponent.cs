namespace DALInterfaces.Models;

public class PcComponent : BaseModel
{
    public string Category { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}