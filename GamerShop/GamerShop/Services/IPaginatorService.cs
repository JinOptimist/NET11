using BusinessLayerInterfaces.Common;
using GamerShop.Models;
using System.Linq.Expressions;
using DALInterfaces.Models;

namespace GamerShop.Services
{
    /// <summary>
    /// Interface for the pagination service, providing methods for obtaining the PaginatorViewModel.
    /// </summary>
    public interface IPaginatorService
    {
        /// <summary>
        /// Get a PaginatorViewModel object for pagination without filtering.
        /// </summary>
        /// <typeparam name="ViewModelTemplate">Type of view objects (ViewModel).</typeparam>
        /// <typeparam name="BlmTemplate">Business logic object type (BLM).</typeparam>
        /// <typeparam name="DbModel">Data model type (DbModel).</typeparam>
        /// <param name="services">Service that implements the IPaginatorServices interface for working with pagination.</param>
        /// <param name="mapViewModelFromBlm">Function to map BLM objects to ViewModel objects.</param>
        /// <param name="page">Page number for pagination.</param>
        /// <param name="perPage">Number of elements on the page.</param>
        /// <returns>PaginatorViewModel object for pagination without filtering.</returns>
        /// <remarks>
        /// This method provides unfiltered pagination using the specified parameters.
        /// </remarks>
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate, DbModel>(
            IPaginatorServices<BlmTemplate, DbModel> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage
            ) where DbModel : BaseModel;

        /// <summary>
        /// Get the PaginatorViewModel object for pagination using filtering.
        /// </summary>
        /// <typeparam name="ViewModelTemplate">Type of view objects (ViewModel).</typeparam>
        /// <typeparam name="BlmTemplate">Business logic object type (BLM).</typeparam>
        /// <typeparam name="DbModel">Data model type (DbModel).</typeparam>
        /// <param name="services">A service that implements the IPaginatorServices interface for working with pagination.</param>
        /// <param name="mapViewModelFromBlm">Function to map BLM objects to ViewModel objects.</param>
        /// <param name="filter">Expression for filtering data.</param>
        /// <param name="page">Page number for pagination.</param>
        /// <param name="perPage">Number of elements on the page.</param>
        /// <returns>PaginatorViewModel object for pagination using filtering.</returns>
        /// <remarks>
        /// This method provides pagination using filtering based on specified parameters.
        /// </remarks>
        PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModelWithFilter<ViewModelTemplate, BlmTemplate, DbModel>(
            IPaginatorServices<BlmTemplate, DbModel> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            Expression<Func<DbModel, bool>> filter,
            string sortingCriteria,
            int page,
            int perPage
        ) where DbModel : BaseModel;
    }
}