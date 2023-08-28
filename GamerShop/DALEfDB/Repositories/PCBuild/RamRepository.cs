using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class RamRepository : BaseRepository<Ram>, IRamRepository
{
    public RamRepository(WebContext context) : base(context)
    {
    }
}