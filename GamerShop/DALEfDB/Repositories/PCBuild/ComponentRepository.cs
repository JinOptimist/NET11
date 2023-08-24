using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class ComponentRepository : BaseRepository<Component>, IComponentRepository
{
    public ComponentRepository(WebContext context) : base(context)
    {
    }
}