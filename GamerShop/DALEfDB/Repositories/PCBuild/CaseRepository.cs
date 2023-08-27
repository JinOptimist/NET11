using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class CaseRepository : BaseRepository<Case>, ICaseRepository
{
    public CaseRepository(WebContext context) : base(context)
    {
    }
}