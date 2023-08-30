using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class SsdRepository : BaseRepository<Ssd>, ISsdRepository
{
    public SsdRepository(WebContext context) : base(context)
    {
    }
}