using DALInterfaces.DataModels.PcBuild;
using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace DALEfDB.Repositories.PCBuild;

public class BuildRepository : BaseRepository<Build>, IBuildRepository
{
    public BuildRepository(WebContext context) : base(context)
    {
    }

    public BuildPaginatorDataModel GetBuildPaginatorDataModel(int page, int perPage)
    {
        var count = _dbSet.Count();

        var builds = _dbSet
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .Where(x => x.IsPrivate == false)
            .Select(dbBuild => new BuildDataModel()
            {
                Id = dbBuild.Id,
                Label = dbBuild.Label,
                CreatorName = dbBuild.Creator.Name,
                CreatorId = dbBuild.Creator.Id,
                DateOfCreate = dbBuild.DateOfCreate,
                GpuName = dbBuild.Gpu!.FullName,
                Price = dbBuild.Price,
                ProcessorName = dbBuild.Processor.FullName,
                Rating = dbBuild.Rating,
            })
            .ToList();

        return new BuildPaginatorDataModel()
        {
            Count = count,
            Page = page,
            PerPage = perPage,
            Builds = builds
        };
    }

    public void CreateBuild(User currentUser, Processor processor, Motherboard motherboard, Gpu? gpu, Case? currentCase,
        Cooler cooler, Hdd? hdd, Ssd? ssd, Ram ram, Psu psu, int ramCount, int ssdCount, int hddCount, int gpuCount, decimal price)
    {
        var build = new Build()
        {
            Creator = currentUser,
            Processor = processor,
            Motherboard = motherboard,
            Gpu = gpu,
            Case = currentCase,
            Cooler = cooler,
            Hdd = hdd,
            Ssd = ssd,
            Ram = ram,
            Psu = psu,
            RamCount = ramCount,
            SsdCount = ssdCount,
            HddCount = hddCount,
            GpusCount = gpuCount,
            Price = price
        };
        Save(build);
    }
}