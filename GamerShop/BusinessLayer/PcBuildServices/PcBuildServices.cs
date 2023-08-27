using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using BusinessLayerInterfaces.PcBuilderServices;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.PCBuild;

namespace BusinessLayer.PcBuildServices
{
    public class PcBuildServices : IBuildServices
    {
        private IBuildRepository _buildRepository;
        private IProcessorRepository _processorRepository;
        private IMotherboardRepository _motherboardRepository;
        private IGpuRepository _gpuRepository;
        private IRamRepository _ramRepository;
        private ISsdRepository _ssdRepository;
        private IHddRepository _hddRepository;
        private ICaseRepository _caseRepository;
        private ICoolerRepository _coolerRepository;
        private IPsuRepository _psuRepository;
        private IUserRepository _userRepository;

        public PcBuildServices(IBuildRepository buildRepository, IProcessorRepository processorRepository, 
            IMotherboardRepository motherboardRepository, IRamRepository ramRepository, IGpuRepository gpuRepository, 
            ISsdRepository ssdRepository, IHddRepository hddRepository, ICaseRepository caseRepository, 
            ICoolerRepository coolerRepository, IPsuRepository psuRepository, IUserRepository userRepository)
        {
            _buildRepository = buildRepository;
            _processorRepository = processorRepository;
            _motherboardRepository = motherboardRepository;
            _ramRepository = ramRepository;
            _gpuRepository = gpuRepository;
            _ssdRepository = ssdRepository;
            _hddRepository = hddRepository;
            _caseRepository = caseRepository;
            _coolerRepository = coolerRepository;
            _psuRepository = psuRepository;
            _userRepository = userRepository;
        }

        public IndexBuildBlm GetIndexBuildBlm(int page, int perPage)
        {
            var data = _buildRepository.GetBuildPaginatorDataModel(page, perPage);
            return new IndexBuildBlm
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Builds = data.Builds
                    .Where(x => x.IsPrivate == false)
                    .Select(model => new ShortBuildBlm
                    {
                        Id = model.Id,
                        Label = model.Label,
                        Price = model.Price.ToString(),
                        Rating = model.Rating,
                        CreatorId = model.CreatorId,
                        CreatorName = model.CreatorName,
                        DateOfCreate = model.DateOfCreate.ToShortDateString(),
                        ProcessorName = model.ProcessorName,
                        GpuName = model.GpuName
                    }).ToList()
            };
        }

        public void CreateNewBuild(NewBuildBlm newBuildBlm)
        {
            var processor = _processorRepository.Get(newBuildBlm.ProcessorId);
            var motherboard = _motherboardRepository.Get(newBuildBlm.MotherboardId);
            var gpu = newBuildBlm.GpuId == null ? null : _gpuRepository.Get(newBuildBlm.GpuId);
            var ssd = newBuildBlm.SsdId == null ? null : _ssdRepository.Get(newBuildBlm.SsdId);
            var hdd = newBuildBlm.HddId == null ? null : _hddRepository.Get(newBuildBlm.HddId);
            var ram = _ramRepository.Get(newBuildBlm.RamId);
            var psu = _psuRepository.Get(newBuildBlm.PsuId);
            var currentCase = _caseRepository.Get(newBuildBlm.CurrentCaseId);
            var cooler = _coolerRepository.Get(newBuildBlm.CoolerId);
            var price = CalculatePrice(processor, motherboard, gpu, newBuildBlm.GpuCount, ssd, 
                newBuildBlm.SsdCount, hdd, newBuildBlm.HddCount, ram, newBuildBlm.RamCount, psu,
                currentCase, cooler);
            var buildDb = new Build()
            {
                Creator = _userRepository.Get(newBuildBlm.CreatorId),
                Processor = processor,
                Motherboard = motherboard,
                Gpu = gpu,
                Ssd = ssd,
                Hdd = hdd,
                Ram = ram,
                Psu = psu,
                Case = currentCase,
                Cooler = cooler,
                isVirtual = false, //TODO
                DateOfCreate = DateTime.Now,
                Label = newBuildBlm.Title,
                IsPrivate = false, //TODO
                GpusCount = newBuildBlm.GpuCount,
                SsdCount = newBuildBlm.SsdCount,
                HddCount = newBuildBlm.HddCount,
                RamCount = newBuildBlm.RamCount,
                Price = price
            };
            _buildRepository.Save(buildDb);
        }

        private decimal CalculatePrice(Processor processor, Motherboard motherboard, Gpu? gpu, int? gpuCount, Ssd? ssd,
            int? ssdCount, Hdd? hdd, int? hddCount, Ram ram, int? ramCount, Psu psu, Case currentCase, Cooler cooler)
        {
            var gpusSum = gpu?.Price * gpuCount ?? 0;
            var ssdSum = ssd?.Price * ssdCount ?? 0;
            var hddSum = hdd?.Price * hddCount ?? 0;
            var ramSum = ram?.Price * ramCount ?? 0;
            return processor.Price + motherboard.Price + gpusSum + ssdSum + hddSum + ramSum + psu.Price +
                   currentCase.Price + cooler.Price;
        }
        
        private IEnumerable<ComponentBlm> GetAllProcessors()
        {
            return _processorRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            });
        }

        private IEnumerable<ComponentBlm> GetAllCases()
        {
            return _caseRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllMotherboards()
        {
            return _motherboardRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllRams()
        {
            return _ramRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllPsus()
        {
            return _psuRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllCoolers()
        {
            return _coolerRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllGpus()
        {
            return _gpuRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllSsd()
        {
            return _ssdRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        private IEnumerable<ComponentBlm> GetAllHdd()
        {
            return _hddRepository.GetAll().Select(c => new ComponentBlm()
            {
                Id = c.Id,
                Name = c.FullName,
                Price = c.Price
            }); 
        }

        public AllComponentsForAddingBlm GetAllComponents()
        {
            return new AllComponentsForAddingBlm()
            {
                Processors = GetAllProcessors(),
                Cases = GetAllCases(),
                Motherboards = GetAllMotherboards(),
                Rams = GetAllRams(),
                Ssds = GetAllSsd(),
                Hdds = GetAllHdd(),
                Coolers = GetAllCoolers(),
                Gpus = GetAllGpus(),
                Psus = GetAllPsus()
            };
        }

        public IEnumerable<BaseBuildBlm> GetAllBuilds()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(BaseBuildBlm buildBlm)
        {
            throw new NotImplementedException();
        }
    }
}
