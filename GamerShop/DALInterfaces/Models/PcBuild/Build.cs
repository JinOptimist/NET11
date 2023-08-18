namespace DALInterfaces.Models.PcBuild;

public class Build : BaseModel
{
    public string Label { get; set; }
    public int[] ProcessorsIds { get; set; }
    public int[] GPUsIds { get; set; }
    public int[] MotherboardsIds { get; set; }
    public int[] StoragesIds { get; set; }
    public int[] PSUsIds { get; set; }
    public int[] RAMsIds { get; set; }
    public int[] ProcessorCullersIds { get; set; }
    public int[] CasesIds { get; set; }
    public DateOnly DateOfCreate { get; set; }
    public bool isVirtual { get; set; }
    public string[]? Photos { get; set; }
    public int UserId { get; set; }
}