using DALInterfaces.Models.RockHall;

namespace DALInterfaces.Repositories.RockHall
{
    public interface IRockMemberRepository : IBaseRepository<RockMember>
    {
        RockMemberPaginatorDataModel GetRockMemberPaginatorDataModel(int page, int perPage);
    }
}
