using BusinessLayerInterfaces.BusinessModels;

namespace BusinessLayerInterfaces.Common
{
    public interface IPaginatorServices<BlmTemplate>
    {
        PaginatorBlm<BlmTemplate> GetPaginatorBlm(int page, int perPage);
    }
}
