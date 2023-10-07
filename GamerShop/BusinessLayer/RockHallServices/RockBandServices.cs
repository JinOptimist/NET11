using BusinessLayerInterfaces.BusinessModels.RockHall.RockBand;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.RockHallServices;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;

namespace BusinessLayer.RockHallServices
{
    public class RockBandServices : IRockBandServices
    {
        private IRockBandRepository _rockBandRepository;
        private IHomeServices _homeServices;

        public RockBandServices(IRockBandRepository rockBandRepository, IHomeServices homeServices)
        {
            _rockBandRepository = rockBandRepository;
            _homeServices = homeServices;
        }

        public void ChooseMember(int bandId, int memberId)
        {
            _rockBandRepository.ChooseFavorite(bandId, memberId);
        }

        public IEnumerable<RockBandGetBlm> GetAll()
        => _rockBandRepository
            .GetAll()
            .Select(dbBand => new RockBandGetBlm
            {
                Id = dbBand.Id,
                FullName = dbBand.FullName,
                
                CreatorName = _homeServices.GetUserById(dbBand.CreatorId).Name
            })
                .ToList();

        public void Remove(int id)
        {
            _rockBandRepository.Remove(id);
        }

        public void Save(RockBandPostBlm rockBandBlm)
        {
            var rockBandDb = new RockBand()
            {
                FullName = rockBandBlm.FullName,
                CreatorId = rockBandBlm.CreatorId
            };
            _rockBandRepository.Save(rockBandDb);
        }

    }
}
