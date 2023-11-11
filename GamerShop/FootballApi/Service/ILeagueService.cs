using FootballApi.DatabaseStuff.DataModels;
using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.VIewModels;

namespace FootballApi.Service
{
    public interface ILeagueService
    {
        IEnumerable<LeagueViewModel> GetLeagues();
        IEnumerable<ShortLeagueViewModel> GetLimetedAmount(int amount);
        PaginatorViewModel<LeagueViewModel> GetForPaginator(int page, int perPage);
        void Save(LeagueViewModel league);
        void Delete(int id);
        int Count();
        IEnumerable<ShortLeagueViewModel> Get(int count, int skipCount);
    }
}
