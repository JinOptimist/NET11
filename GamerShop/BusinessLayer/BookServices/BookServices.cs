

using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.DataModels.Books;
using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace BusinessLayer.BookServices
{
    public class BookServices : IBookServices
    {
        private IBookRepository _bookRepository;
        private IHomeServices _homeServices;
        private IAuthorServices _authorServices;

        public BookServices(IBookRepository bookRepository, IHomeServices homeServices, IAuthorServices authorServices)
        {
            _bookRepository = bookRepository;
            _homeServices = homeServices;
            _authorServices = authorServices;
        }

        public IEnumerable<BookGetBlm> GetAll()
            => _bookRepository.GetAll().Select(dbMember => new BookGetBlm
            {
                Id = dbMember.Id,
                Name = dbMember.Name,
                YearOfIssue = dbMember.YearOfIssue,
                Authors = _authorServices.GetAll().Where(x => dbMember.Authors.Select(a=> a.Id).Contains(x.Id)).ToList()
            }).ToList();

        public void Save(BookPostBlm bookBlm)
        {
            var bookMemberDb = new Book()
            {
                Authors = ,
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
                    Authors = _authorServices.GetAll().Where(x => bookDataModel.Authors.Select(a => a.Id).Contains(x.Id)).ToList(),
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
                Authors = dbBook.Authors,
                Name = dbBook.Name,
                YearOfIssue = dbBook.YearOfIssue
            };
        }
    }
}
