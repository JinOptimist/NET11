using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class PsuRepository : BaseRepository<Psu>, IPsuRepository
{
    public PsuRepository(WebContext context) : base(context)
    {
    }
}