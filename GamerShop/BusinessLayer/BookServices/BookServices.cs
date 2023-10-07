using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.DataModels.Books;
using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace BusinessLayer.BookServices
{
    public class BookServices : IBookServices
    {
        private IBookRepository _bookRepository;
        private IHomeServices _homeServices;

        public BookServices(IBookRepository bookRepository, IHomeServices homeServices)
        {
            _bookRepository = bookRepository;
            _homeServices = homeServices;
        }

        public IEnumerable<BookGetBlm> GetAll()
            => _bookRepository.GetAll()
               .Select(dbMember => new BookGetBlm
               {
                   Id = dbMember.Id,
                   Author = dbMember.Author,
                   Name = dbMember.Name,
                   YearOfIssue = dbMember.YearOfIssue
               })
               .ToList();

        public void Save(BookPostBlm bookBlm)
        {
            var bookMemberDb = new Book()
            {
                Author = bookBlm.Author,
                Name = bookBlm.Name,
                YearOfIssue = bookBlm.YearOfIssue
            };

            _bookRepository.Save(bookMemberDb);
        }

        public void Remove(int id)
        {
            _bookRepository.Remove(id);
        }

        public PaginatorBlm<BookGetBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _bookRepository.GetPaginatorDataModel(MapBookToBookDataModel, page, perPage);

            return new PaginatorBlm<BookGetBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(bookDataModel => new BookGetBlm
                {
                    Id = bookDataModel.Id,
                    Author = bookDataModel.Author,
                    Name = bookDataModel.Name,
                    YearOfIssue = bookDataModel.YearOfIssue

                }).ToList()
            };
        }

        private BookDataModel MapBookToBookDataModel(Book dbBook)
        {
            return new BookDataModel
            {
                Id = dbBook.Id,
                Author = dbBook.Author,
                Name = dbBook.Name,
                YearOfIssue = dbBook.YearOfIssue
            };
        }
    }
}
