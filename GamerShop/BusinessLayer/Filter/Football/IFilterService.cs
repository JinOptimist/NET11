using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.DataModels;
using System.Collections;

namespace BusinessLayer.Filter.Football
{
    public interface IFilterService
    {
        IEnumerable<FilterDataModel> GetAllFilters(List<FilterModelBlm> filtersBlm);
    }
}
