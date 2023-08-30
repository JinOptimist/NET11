using BusinessLayerInterfaces.Common;
using GamerShop.Models;

namespace GamerShop.Services
{
    public interface IPaginatorService
    {
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm, 
            int page,
            int perPage);
    }
}