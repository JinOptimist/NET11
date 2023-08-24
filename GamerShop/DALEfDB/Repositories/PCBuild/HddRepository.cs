using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class HddRepository : BaseRepository<Hdd>, IHddRepository 
{
    public HddRepository(WebContext context) : base(context)
    {
    }
}