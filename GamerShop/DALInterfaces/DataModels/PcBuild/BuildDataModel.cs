namespace DALInterfaces.DataModels.PcBuild;

public class BuildDataModel
{
    public int Id { get; set; }
    public string Label { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string ProcessorName { get; set; }
    public string? GpuName { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public int CreatorId { get; set; }
    public string CreatorName { get; set; }

    public bool IsPrivate { get; set; }
}