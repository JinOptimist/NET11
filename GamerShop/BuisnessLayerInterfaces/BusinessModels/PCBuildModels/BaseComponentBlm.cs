namespace BusinessLayerInterfaces.BusinessModels.PCBuildModels;

public abstract class BaseComponentBlm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}