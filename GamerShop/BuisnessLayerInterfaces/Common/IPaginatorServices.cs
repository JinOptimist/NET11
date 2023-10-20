using System.Linq.Expressions;
using BusinessLayerInterfaces.BusinessModels;
using DALInterfaces.Models;

namespace BusinessLayerInterfaces.Common
{
    /// <summary>
    /// An interface for pagination services that provide basic methods for working with pagination and filtering.
    /// </summary>
    /// <typeparam name="BlmTemplate">The type of business logic objects that will be used in pagination.</typeparam>
    /// <typeparam name="DbModel">The type of data models that will be used in pagination.</typeparam>
    public interface IPaginatorServices<BlmTemplate, DbModel> where DbModel: BaseModel
    {
        /// <summary>
        /// Get a PaginatorBlm object for pagination without filtering.
        /// </summary>
        /// <param name="page">Page number for pagination.</param>
        /// <param name="perPage">Number of elements on the page.</param>
        /// <returns>PaginatorBlm object for pagination without filtering.</returns>
        PaginatorBlm<BlmTemplate> GetPaginatorBlm(int page, int perPage);

        /// <summary>
        /// Get a PaginatorBlm object for pagination using filtering by a given expression.
        /// </summary>
        /// <param name="filter">Expression for filtering data.</param>
        /// <param name="page">Page number for pagination.</param>
        /// <param name="perPage">Number of elements on the page.</param>
        /// <returns>PaginatorBlm object for pagination using filtering.</returns>
        /// <remarks>
        /// This method has a default implementation, which makes it optional for implementation in all interface descendants. However, to customize pagination with filtering to meet specific requirements, it is recommended to override this method in inheriting classes.
        /// </remarks>
        PaginatorBlm<BlmTemplate> GetPaginatorBlmWithFilter(
            Expression<Func<DbModel, bool>> filter,
            string sortingCriteria,
            int page,
            int perPage,
            bool isAscending) => GetPaginatorBlm(page, perPage);
    }
}
