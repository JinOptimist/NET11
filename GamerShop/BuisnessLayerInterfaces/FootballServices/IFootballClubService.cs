using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Football;
using BusinessLayerInterfaces.Common;
using BusinessLayerInterfaces.Common.Dtos;
using BusinessLayerInterfaces.FootballServices.Dtos;
using DALInterfaces.Models.Football;

namespace BusinessLayerInterfaces.FootballService
{
    public interface IFootballClubService : IPaginatorServices<FootballClubBlm> 
    {
        Task Delete(int id);
        Task<IEnumerable<FootballClubBlm>> GetAll();
        Task Save(FootballClubBlm footClub);
        Task<PaginatorDto<FootballClubDto>> GetDataForPaginator(int page, int perPage);

    }
}
