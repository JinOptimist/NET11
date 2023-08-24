using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB.Repositories.PCBuild;

public class BuildRepository : BaseRepository<Build>, IBuildRepository
{
    public BuildRepository(WebContext context) : base(context)
    {
    }
    
}