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
        private IUserRepository _userRepository;

        public BgServices(IPersRepository persRepository, IUserRepository userRepository)
        {
            _persRepository = persRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<BaldursGateBml> GetAllHero()
            => _persRepository
                .GetAll()
                .Select(x => new BaldursGateBml
                {
                    Id = x.Id,
                    Name = x.Name,
                    Class = x.Class,
                    Creater = new UserBlm
                    {   Id = x.Creator.Id,
                        Name = x.Creator.Name,
                    },
                });
            

        void IBgServices.Remove(int id)
        {
            _persRepository.Remove(id);
        }

        public void Save(BaldursGateBml BgBml)
        {
            _persRepository.Save(new Hero
            {
                Bone = BgBml.Bone,
                Name = BgBml.Name,
                Class = BgBml.Class,
                Races = BgBml.Races,
                Subrace = BgBml.Subrace,
                Оrigin = BgBml.Оrigin,
                Creator = _userRepository.Get(BgBml.Id)
            });
        }
    }
}
