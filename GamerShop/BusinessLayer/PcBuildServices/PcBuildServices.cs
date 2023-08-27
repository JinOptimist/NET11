using BusinessLayerInterfaces.BusinessModels.PCBuildModels;
using BusinessLayerInterfaces.PcBuilderServices;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories.PCBuild;

namespace BusinessLayer.PcBuilderServices
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

        public PcBuildServices(IBuildRepository buildRepository, IProcessorRepository processorRepository, IMotherboardRepository motherboardRepository, IRamRepository ramRepository, IGpuRepository gpuRepository, ISsdRepository ssdRepository, IHddRepository hddRepository, ICaseRepository caseRepository, ICoolerRepository coolerRepository, IPsuRepository psuRepository)
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

        public void CreateNewBuild(int currentUserId, int viewModelProcessorsId, int viewModelMotherboardsId, int viewModelGpusId,
            int viewModelCasesId, int viewModelCoolersId, int viewModelHddsId, int viewModelSsdsId, int viewModelRamsId,
            int viewModelPsusId)
        {
            
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
