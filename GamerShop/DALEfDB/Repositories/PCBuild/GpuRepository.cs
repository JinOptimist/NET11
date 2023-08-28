using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class GpuRepository : BaseRepository<Gpu>, IGpuRepository
{
    public GpuRepository(WebContext context) : base(context)
    {
    }
}