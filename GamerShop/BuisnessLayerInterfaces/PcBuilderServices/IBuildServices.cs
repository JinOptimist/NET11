using BusinessLayerInterfaces.BusinessModels.PCBuildModels;

namespace BusinessLayerInterfaces.PcBuilderServices;

public interface IBuildServices
{
    IEnumerable<BaseBuildBlm> GetAllBuilds();
    void Remove(int id);
    void Save(BaseBuildBlm buildBlm);
    public AllComponentsForAddingBlm GetAllComponents();
    IndexBuildBlm GetIndexBuildBlm(int page, int perPage);
    void CreateNewBuild(int currentUserId, int ProcessorsId, int MotherboardsId, int GpusId, int CaseId, int CoolerId, 
        int HddId, int SsdId, int RamId, int PsuId, int RamCount, int SsdCount, int HddCount, int GpuCount);
}