using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class ProcessorRepository : BaseRepository<Processor>, IProcessorRepository
{
    public ProcessorRepository(WebContext context) : base(context)
    {
    }

}