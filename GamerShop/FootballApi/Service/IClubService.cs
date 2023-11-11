using FootballApi.DatabaseStuff.DataModels;
using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.VIewModels;

namespace FootballApi.Service
{
    public interface IClubService
    {
        IEnumerable<ClubViewModel> GetClubs();
        PaginatorViewModel<ClubViewModel> GetForPaginator(int page, int perPage);
        void Save(ClubViewModel footClub);
        void Delete(int id);

    }
}
