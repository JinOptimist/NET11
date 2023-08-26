using BusinessLayerInterfaces.BusinessModels.PCBuildModels;

namespace BusinessLayerInterfaces.PcBuilderServices;

public interface IBuildServices
{
    IEnumerable<BaseBuildBlm> GetAllBuilds();
    void Remove(int id);
    void Save(BaseBuildBlm buildBlm);
    public AllComponentsForAddingBlm GetAllComponents();
    IndexBuildBlm GetIndexBuildBlm(int page, int perPage);
}