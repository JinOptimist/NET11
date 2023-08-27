using DALInterfaces.DataModels.PcBuild;
using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;

namespace DALInterfaces.Repositories.PCBuild;

public interface IBuildRepository : IBaseRepository<Build>
{
    BuildPaginatorDataModel GetBuildPaginatorDataModel(int page, int perPage);
}