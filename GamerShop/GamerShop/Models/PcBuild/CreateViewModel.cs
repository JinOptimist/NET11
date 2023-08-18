namespace GamerShop.Models.PcBuild;

public class CreateViewModel
{
    public int CurrentUserId { get; set; }
    public DateOnly DateNow { get; set; }
    public bool IsVirtual { get; set; }
    public int ProcessorId { get; set; }
    public int GPUId { get; set; }
    public int MotherboardId { get; set; }
    public int RAMId { get; set; }
    public int PSUId { get; set; }
    public int[] StorageId { get; set; }
    public int ProcessorCullerId { get; set; }
    public int CaseId { get; set; }
    public string PhotoPath { get; set; }
}