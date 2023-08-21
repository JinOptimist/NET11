using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.PcBuilderServices
{
    public interface IPcComponentServices
    {
        IEnumerable<PcComponentBlm> GetAllPcComponents();

        void Remove(int id);
        void Save(PcComponentBlm pcComponentBlm);
    }
}
