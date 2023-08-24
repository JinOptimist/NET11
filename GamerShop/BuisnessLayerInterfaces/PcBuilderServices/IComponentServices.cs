using BusinessLayerInterfaces.BusinessModels.PCBuildModels;

namespace BusinessLayerInterfaces.PcBuilderServices;

public interface IComponentServices
{
    IEnumerable<ComponentBlm> GetAllPcComponents();
    void Remove(int id);
    void Save(ComponentBlm componentBlm);
}