using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.RockHall.RockMember;
using BusinessLayerInterfaces.Common;
using BusinessLayerInterfaces.RockHallServices;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.DataModels.RockHall;
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
                CurrentBandName = dbMember.CurrentBand?.FullName ?? "---"
            })
                .ToList();

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

        PaginatorBlm<RockMemberGetBlm> IPaginatorServices<RockMemberGetBlm>.GetPaginatorBlm(int page, int perPage)
        {
            var data = _rockMemberRepository.GetPaginatorDataModel(MapRockMemberToRockMemberDataModel, page, perPage);

            return new PaginatorBlm<RockMemberGetBlm>
            {
                Count = data.Count,
                PerPage = data.PerPage,
                Page = data.Page,
                Items = data.Items.Select(rockMemberDataModel => new RockMemberGetBlm
                {
                    Id = rockMemberDataModel.Id,
                    FullName = rockMemberDataModel.FullName,
                    EntryYear = rockMemberDataModel.EntryYear,
                    YearOfBirth = rockMemberDataModel.YearOfBirth,
                    Genre = rockMemberDataModel.Genre,
                    CurrentBandName = rockMemberDataModel.CurrentBandName,
                    CreatorName = _homeServices.GetUserById(rockMemberDataModel.CreatorId).Name
                }).ToList()
            };
        }

        private RockMemberDataModel MapRockMemberToRockMemberDataModel(RockMember dbRockMember)
        {
            return new RockMemberDataModel
            {
                Id = dbRockMember.Id,
                FullName = dbRockMember.FullName,
                EntryYear = dbRockMember.EntryYear,
                YearOfBirth = dbRockMember.YearOfBirth,
                Genre = dbRockMember.Genre,
                CurrentBandName = dbRockMember.CurrentBand?.FullName ?? "¯\\_(ツ)_/¯",
                CreatorId = dbRockMember.CreatorId
            };
        }
    }
}
