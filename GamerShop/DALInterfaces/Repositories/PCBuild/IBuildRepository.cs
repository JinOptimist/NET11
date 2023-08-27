using DALInterfaces.DataModels.PcBuild;
using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;

namespace DALInterfaces.Repositories.PCBuild;

public interface IBuildRepository : IBaseRepository<Build>
{
    BuildPaginatorDataModel GetBuildPaginatorDataModel(int page, int perPage);
    void CreateBuild(User currentUser, Processor processor, Motherboard motherboard, Gpu? gpu, Case? currentCase, 
        Cooler cooler, Hdd? hdd, Ssd? ssd, Ram ram, Psu psu, int ramCount, int ssdCount, int hddCount, int gpuCount, decimal price);
}