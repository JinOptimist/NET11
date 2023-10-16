using DALInterfaces.DataModels;
using System.Collections;

namespace BusinessLayer.Filter.Football
{
    public class FootballClubFilter : IFootballClubFilter
    {
        public FilterDataModel Id(int id = -1)
        {

            var expretionForGEtDefultValue = new Dictionary<string, string>();
            expretionForGEtDefultValue.Add("Take", "5");

            var filterModel = new FilterDataModel
            {
                Expretion = (id >= 0) ? $"x => x.Id == {id}" : null,
                PropName = "Id",
                NameForUser = "Отфильтровать по ID",
                ExpretionForDefultValue = expretionForGEtDefultValue,
                Type   = typeof(int),
                
            };

            return filterModel;
        }
        public FilterDataModel FootballLeagueinfo(int id = -1)
        {
            var expretionForGEtDefultValue = new Dictionary<string, string>();
            expretionForGEtDefultValue.Add("Take", "5");

            var filterModel = new FilterDataModel
            {
                Expretion = (id >= 0) ? $"x => x.FootballLeagueinfo.Id == {id}" : null,
                PropName = "FootballLeagueinfo",
                NameForUser = "Отфильтровать по лиги",
                ExpretionForDefultValue = expretionForGEtDefultValue,
                Type = typeof(int),
            };
            return filterModel;
        }

        public IEnumerable<FilterDataModel> GetAllFilters()
        {
            List<FilterDataModel> filters = new List<FilterDataModel>();

            filters.Add(Id());
            filters.Add(FootballLeagueinfo());

            return filters;


        }
    }
}
