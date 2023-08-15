using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.UserServices
{
    public class PcComponentServices : IPcComponentServices
    {
        private IPcComponentsRepository _componentsRepository;

        public PcComponentServices(IPcComponentsRepository componentsRepository)
        {
            _componentsRepository = componentsRepository;
        }

        public IEnumerable<PcComponentBlm> GetAllPcComponents() 
            => _componentsRepository
                .GetAll()
                .Select(component => new PcComponentBlm()
                {
                    Id = component.Id,
                    Category = component.Category,
                    Price = component.Price,
                    Title = component.Title
                })
                .ToList();

        public void Remove(int id)
        {
            _componentsRepository.Remove(id);
        }

        public void Save(PcComponentBlm pcComponentBlm)
        {
            var dbComponent = new PcComponent()
            {
                Title = pcComponentBlm.Title,
                Category = pcComponentBlm.Category,
                Price = pcComponentBlm.Price
            };
            _componentsRepository.Save(dbComponent);
        }
    }
}
