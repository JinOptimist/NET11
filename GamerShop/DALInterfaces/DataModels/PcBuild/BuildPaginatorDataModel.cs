namespace DALInterfaces.DataModels.PcBuild;

public class BuildPaginatorDataModel
{
    public int Count { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public List<BuildDataModel> Builds { get; set; }
}