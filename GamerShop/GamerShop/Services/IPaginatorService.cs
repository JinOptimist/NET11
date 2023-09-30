using BusinessLayerInterfaces.BusinessModels.Movies;
using BusinessLayerInterfaces.Common;
using GamerShop.Models;
using System.Linq.Expressions;
using DALInterfaces.Models.Movies;

namespace GamerShop.Services
{
    public interface IPaginatorService
    {
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm, 
            int page,
            int perPage);

        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModelWithFilter<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            Expression<Func<Collection, bool>> filter, // Параметр фильтра
            int page,
            int perPage
        );
    }
}