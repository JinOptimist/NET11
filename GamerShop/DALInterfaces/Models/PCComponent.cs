namespace DALInterfaces.Models;

public class PCComponent : BaseModel
{
    public string Category { get; set; }
    public string Title { get; set; }
    public Decimal Price { get; set; }
}