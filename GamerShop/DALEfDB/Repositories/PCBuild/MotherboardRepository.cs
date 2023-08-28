using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class MotherboardRepository : BaseRepository<Motherboard>, IMotherboardRepository
{
    public MotherboardRepository(WebContext context) : base(context)
    {
    }
}