using System.Linq.Expressions;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Movies;
using DALInterfaces.Models.Movies;

namespace BusinessLayerInterfaces.Common
{
    public interface IPaginatorServices<BlmTemplate>
    {
        PaginatorBlm<BlmTemplate> GetPaginatorBlm(int page, int perPage);

        PaginatorBlm<BlmTemplate> GetPaginatorBlmWithFilter(
            Expression<Func<Collection, bool>> filter, // Параметр фильтра
            int page,
            int perPage);
    }
}
