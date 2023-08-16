using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.BgServices
{
    public class BgServices : IBgServices
    {
        private IPersRepository _persRepository;

        public BgServices(IPersRepository persRepository)
        {
            _persRepository = persRepository;
        }

        public IEnumerable<BaldursGateBml> GetAllHero()
         => _persRepository
            .GetAll()
            .Select(x => new BaldursGateBml
            {
                Id = x.Id,
                Name = x.Name,
                Class = x.Class,
            })
            .ToList();

        void IBgServices.Remove(int id)
        {
            _persRepository.Remove(id);
        }

        public void Save(BaldursGateBml BgBml)
        {
            _persRepository.Save(new Pers
            {
                Bone = BgBml.Bone,
                Name = BgBml.Name,
                Class = BgBml.Class,
                Races = BgBml.Races,
                Subrace = BgBml.Subrace,
                Оrigin = BgBml.Оrigin
            });
        }
    }
}
