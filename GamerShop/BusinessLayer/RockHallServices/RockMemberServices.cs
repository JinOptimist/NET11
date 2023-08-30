using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.RockHallServices;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;

namespace BusinessLayer.RockHallServices
{
    public class RockMemberServices : IRockMemberServices
    {
        private readonly IRockMemberRepository _rockMemberRepository;
        private readonly IHomeServices _homeServices;

        public RockMemberServices(IRockMemberRepository rockMemberRepository, IHomeServices homeServices)
        {
            _rockMemberRepository = rockMemberRepository;
            _homeServices = homeServices;
        }

        public IEnumerable<RockMemberGetBlm> GetAll()
        => _rockMemberRepository
            .GetAll()
            .Select(dbMember => new RockMemberGetBlm
            {
                Id = dbMember.Id,
                FullName = dbMember.FullName,
                Genre = dbMember.Genre,
                YearOfBirth = dbMember.YearOfBirth,
                EntryYear = dbMember.EntryYear,
                CreatorName = _homeServices.GetUserById(dbMember.CreatorId).Name,
                CurrentBand = dbMember.CurrentBand?.FullName ?? "---"
            })
                .ToList();

        public RockMemberPaginatorBlm GetPaginatorBlm(int page, int perPage)
        {
            var data = _rockMemberRepository.GetRockMemberPaginatorDataModel(page, perPage);
            return new RockMemberPaginatorBlm
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                RockMembers = data.RockMembers
                .Select(dbMember => new RockMemberGetBlm
                {
                    Id = dbMember.Id,
                    FullName = dbMember.FullName,
                    Genre = dbMember.Genre,
                    YearOfBirth = dbMember.YearOfBirth,
                    EntryYear = dbMember.EntryYear,
                    CreatorName = _homeServices.GetUserById(dbMember.CreatorId).Name,
                    CurrentBand = dbMember.CurrentBand?.FullName ?? "---"
                })
                .ToList()
            };
        }

        public void Remove(int id)
        {
            _rockMemberRepository.Remove(id);
        }

        public void Save(RockMemberPostBlm rockMemberBlm)
        {
            var rockMemberDb = new RockMember()
            {
                FullName = rockMemberBlm.FullName,
                Genre = rockMemberBlm.Genre,
                EntryYear = rockMemberBlm.EntryYear,
                YearOfBirth = rockMemberBlm.YearOfBirth,
                CreatorId = rockMemberBlm.CreatorId
            };
            _rockMemberRepository.Save(rockMemberDb);
        }
    }
}
