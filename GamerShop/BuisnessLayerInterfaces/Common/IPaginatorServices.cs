using BusinessLayerInterfaces.BusinessModels;
using System.Collections;

namespace BusinessLayerInterfaces.Common
{
    public interface IPaginatorServices<BlmTemplate>
    {
        PaginatorBlm<BlmTemplate> GetPaginatorBlm(int page, int perPage);
        PaginatorBlm<BlmTemplate> GetPaginatorBlm(int page, int perPage, IEnumerable<FilterModelBlm> filters) 
        {
          throw new NotImplementedException();
        }
    }
}
