using DALInterfaces.DataModels;

namespace BusinessLayer.Filter.Football
{
    public interface IFootballClubFilter : IFilterService
    {
        public FilterDataModel Id(int id);
        public FilterDataModel FootballLeagueinfo(int id);
    }
}
