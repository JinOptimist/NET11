using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.Models;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.BG;

namespace BusinessLayer.BgServices
{
    public class BgServices : IBgServices
    {
        private IHeroRepository _heroRepository;
        private IUserRepository _userRepository;

        public BgServices(IHeroRepository heroRepository, IUserRepository userRepository)
        {
            _heroRepository = heroRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<BaldursGateBml> GetAllHero()
            => _heroRepository
                .GetAll()
                .Select(x => new BaldursGateBml
                {
                    //Id = x.Id,
                    //Name = x.Name,
                    //Class = x.Class,
                    //CreatorId = new UserBlm { Name = _userRepository.Get(x.CreatorId).Name},
                   
                });
            

        void IBgServices.Remove(int id)
        {
            _heroRepository.Remove(id);
        }

        public void Save(BaldursGateBml BgBml)
        {
            _heroRepository.Save(new Heros
            {
                //Bone = BgBml.Bone,
                //Name = BgBml.Name,
                //Class = BgBml.Class,
                //Race = BgBml.Races,
                //Subrace = BgBml.Subrace,
                //Оrigin = BgBml.Оrigin,
                //CreatorId = BgBml.CreatorId.Id
            });
        }
    }
}
