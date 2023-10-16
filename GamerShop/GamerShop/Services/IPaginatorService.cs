using BusinessLayerInterfaces.Common;
using GamerShop.Models;
using System.Collections;

namespace GamerShop.Services
{
    public interface IPaginatorService
    {
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage);
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage,
            IEnumerable<FilterViewModel> filters);
    }
}