using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.Common;
using GamerShop.Models;
using System.Collections;

namespace GamerShop.Services
{
    public class PaginatorService : IPaginatorService
    {
        public PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage
            )
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

        public PaginatorViewModel<ViewModelTemplate> GetPaginatorViewModel<ViewModelTemplate, BlmTemplate>(
            IPaginatorServices<BlmTemplate> services,
            Func<BlmTemplate, ViewModelTemplate> mapViewModelFromBlm,
            int page,
            int perPage,
            IEnumerable<FilterViewModel> filters
            )
         {
            var currentFilters = filters.Select(x => new FilterModelBlm
            {
                PropName = x.PropName,
                CurrentValueBool = x.CurrentValueBool,
                CurrentValueInt = x.CurrentValueInt,
                CurrentValueStr = x.CurrentValueStr,
                Expretion = x.NameForUser,
                Comparemark = x.CompareMark

            }).ToList();

            var dataFromBl = services.GetPaginatorBlm(page, perPage, currentFilters);

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
                    .ToList(),
                Filters = dataFromBl.Filters.Select(x => new FilterViewModel { CurrentValueInt =  x.CurrentValueInt, CurrentValueStr = x.CurrentValueStr, CurrentValueBool = x.CurrentValueBool, PropName = x.PropName , NameForUser = x.NameForUser }).ToList()

            };

            return viewModel;
        }
    }
}
