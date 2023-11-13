using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerInterfaces.BgServices;
using BusinessLayerInterfaces.BusinessModels.BG;
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
        private IClassRepository _classRepository;
        private IOriginRepository _originRepository;
        private IRaceRepository _raceRepository;
        private ISubraceRepository _subraceRepository;
        public BgServices(IHeroRepository heroRepository, IUserRepository userRepository, IClassRepository classRepository, IOriginRepository originRepository, IRaceRepository raceRepository, ISubraceRepository subraceRepository)
        {
            _heroRepository = heroRepository;
            _userRepository = userRepository;
            _classRepository = classRepository;
            _originRepository = originRepository;
            _raceRepository = raceRepository;
            _subraceRepository = subraceRepository;
        }

        private IEnumerable<BaseAtributeBml> GetAllClass()
        {
            return _classRepository.GetAll().Select(c => new BaseAtributeBml()
            {
                Id = c.Id,
                Name = c.Name,
            });
        }


        private IEnumerable<BaseAtributeBml> GetAllRace()
        {
            return _raceRepository.GetAll().Select(c => new BaseAtributeBml()
            {
                Id = c.Id,
                Name = c.Name,
            });
        }

        private IEnumerable<BaseAtributeBml> GetSubrace()
        {
            return _subraceRepository.GetAll().Select(c => new BaseAtributeBml()
            {
                Id = c.Id,
                Name = c.Name,

            });
        }

        private IEnumerable<BaseAtributeBml> GetOrigin()
        {
            return _originRepository.GetAll().Select(c => new BaseAtributeBml()
            {
                Id = c.Id,
                Name = c.History,

            });
        }

        public AllAtributeForAddingBml GetAllAtribute()
        {
            return new AllAtributeForAddingBml()
            {
                Class = GetAllClass(),
                Race = GetAllRace(),
                Subrace = GetSubrace(),
                Origin = GetOrigin()

            };


        }

        public void CreateNewHero(NewBGBml newBGBml)
        {
            var Class = _classRepository.Get(newBGBml.ClassId);
            var Race = _raceRepository.Get(newBGBml.RaceId);
            var Subrace = _subraceRepository.Get(newBGBml.SubraceId);
            var Origin = _originRepository.Get(newBGBml.OriginId);

            var HeroDB = new Heros()
            {
                UserCreator = _userRepository.Get(newBGBml.CreatorId),
                Name = newBGBml.Name,
                Bone = newBGBml.Bone,
                Class = Class,
                Race = Race,
                Subrace = Subrace,
                Оrigin = Origin
            };
            _heroRepository.Save(HeroDB);
        }

        public CharacterListBml GetCharacterListBml(int page, int perPage)
        {
            var data = _heroRepository.GetHeroPaginatorDataModel(page, perPage);
            return new CharacterListBml
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                HeroList = data.Heros
                    .Select(m => new BaldursGateBml
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Class = m.Class,
                        Races = m.Race,
                        Subrace = m.Subrace,
                        Bone = m.Bone,
                        Оrigin = m.Оrigin,
                        CreatorId = m.CreatorId,
                    }).ToList()
            };
        }

        public IEnumerable<BaldursGateBml> GetAllHero()
        {
            throw new NotImplementedException();
        }

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
        public List<string> GetHeroList()
        {
            return _heroRepository.GetAll().Select(x => x.Name).ToList();
        }
        
    }
}
