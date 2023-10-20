using System.Linq.Expressions;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models;
using GamerShop.Models;

namespace GamerShop.Services
{
    public class PaginatorService : IPaginatorService
    {
        public PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate, DbModel>(
            IPaginatorServices<BlmTemplate, DbModel> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage
            ) where DbModel : BaseModel
        {
            var dataFromBl = services.GetPaginatorBlm(page, perPage);

            var addtionalPageNumber = dataFromBl.Count % dataFromBl.PerPage == 0
                ? 0
                : 1;

            var availablePages = Enumerable
                .Range(1, dataFromBl.Count / dataFromBl.PerPage + addtionalPageNumber)
                .ToList();

            var viewModel = new PaginatorViewModel<ViewModelTemplate>
            {
                Page = dataFromBl.Page,
                PerPage = dataFromBl.PerPage,
                Count = dataFromBl.Count,
                AvailablePages = availablePages,
                Items = dataFromBl
                    .Items
                    .Select(blm => mapViewModelFromBlm(blm))
                    //.Select(mapViewModelFromBlm)
                    .ToList()
            };

            return viewModel;
        }

        public PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModelWithFilter<ViewModelTemplate, BlmTemplate,
            DbModel>(IPaginatorServices<BlmTemplate, DbModel> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            Expression<Func<DbModel, bool>> filter,
            string sortingCriteria,
            int page,
            int perPage
        ) where DbModel : BaseModel
        {
            var dataFromBl = services.GetPaginatorBlmWithFilter(filter, sortingCriteria, page, perPage); // Используем новый метод с фильтром

            var additionalPageNumber = dataFromBl.Count % dataFromBl.PerPage == 0
                ? 0
                : 1;

            var availablePages = Enumerable
                .Range(1, dataFromBl.Count / dataFromBl.PerPage + additionalPageNumber)
                .ToList();

            var viewModel = new PaginatorViewModel<ViewModelTemplate>
            {
                Page = dataFromBl.Page,
                PerPage = dataFromBl.PerPage,
                Count = dataFromBl.Count,
                AvailablePages = availablePages,
                Items = dataFromBl
                    .Items
                    .Select(blm => mapViewModelFromBlm(blm))
                    .ToList()
            };

            return viewModel;
        }


        public void Test()
        {
            var intArray = new List<int>() { 1, 2, 3, 4 };

            var stringArray = new List<string>() { "first", "second"};

            var firstNumber = MyFirst(intArray);

            var str = MyFirst(stringArray);
        }

        public Template MyFirst<Template>(IEnumerable<Template> list)
        {
            return list.First();
        }
    }
}
