using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.Repositories;
using System.Collections.Generic;

namespace FootballApi.DatabaseStuff.Repositories.Leagues
{
    public interface ILeagueRepository:IBaseRepository<League>
    {
        IEnumerable<ShortLeagueDataModel> GetLimetedAmount(int amount);
        IEnumerable<ShortLeagueDataModel> Get(int count, int skipCount);
    }
}
