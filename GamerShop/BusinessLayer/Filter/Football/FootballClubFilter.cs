using BusinessLayerInterfaces.BusinessModels;
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
                Expretion =  $"x => x.Id == {id}",
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
                Expretion =  $"x => x.FootballLeagueinfo.Id == {id}",
                PropName = "FootballLeagueinfo",
                NameForUser = "Отфильтровать по лиги",
                ExpretionForDefultValue = expretionForGEtDefultValue,
                Type = typeof(int),
            };
            return filterModel;
        }

        public IEnumerable<FilterDataModel> GetAllFilters(List<FilterModelBlm> filtersBlm)
        {
            List<FilterDataModel> filters = new List<FilterDataModel>();

            if (filtersBlm.Count() != 0)
            {
                filters.Add(Id(filtersBlm.First(x => x.PropName == "Id").CurrentValueInt));
                filters.Add(FootballLeagueinfo(filtersBlm.First(x => x.PropName == "FootballLeagueinfo").CurrentValueInt));
            }
            else 
            {
                filters.Add(Id());
                filters.Add(FootballLeagueinfo());
            }
            return filters;


        }
    }
}
