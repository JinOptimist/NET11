using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class CoolerRepository : BaseRepository<Cooler>, ICoolerRepository
{
    public CoolerRepository(WebContext context) : base(context)
    {
    }
}