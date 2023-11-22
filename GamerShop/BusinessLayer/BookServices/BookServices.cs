using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
using DALInterfaces.DataModels.Books;
using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;
using System.Xml.Linq;

namespace BusinessLayer.BookServices
{
    public class BookServices : IBookServices
    {
        private IBookRepository _bookRepository;
        private IHomeServices _homeServices;
        private IAuthorRepository _authorRepository;

        public BookServices(IBookRepository bookRepository, IHomeServices homeServices, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _homeServices = homeServices;
            _authorRepository = authorRepository;
        }

        public IEnumerable<BookGetBlm> GetAll()
            => _bookRepository.GetAll().Select(dbMember => new BookGetBlm
            {
                Id = dbMember.Id,
                Name = dbMember.Name,
                YearOfIssue = dbMember.YearOfIssue,
                Authors =
                dbMember.Authors.Select(x => new ShortAuthorBlm
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList(),
            }).ToList();

        public void Save(BookPostBlm bookBlm)
        {
            var bookMemberDb = new Book()
            {
                Name = bookBlm.Name,
                YearOfIssue = bookBlm.YearOfIssue,
                Authors = bookBlm.Authors.Select(x => _authorRepository.Get(x.Id)).ToList()
        };

            _bookRepository.Save(bookMemberDb);
        }

        public void Remove(int id)
        {
            _bookRepository.Remove(id);
        }

        public PaginatorBlm<BookGetBlm> GetPaginatorBlm(int page, int perPage)
        {
            var data = _bookRepository.GetBookPaginatorDataModel(page, perPage);
            ////GetPaginatorDataModel(MapBookToBookDataModel, page, perPage);

            return new PaginatorBlm<BookGetBlm>
            {
                Count = data.Count,
                Page = data.Page,
                PerPage = data.PerPage,
                Items = data.Items.Select(bookDataModel => new BookGetBlm
                {
                    Id = bookDataModel.Id,
                    Authors = bookDataModel.Authors.Select(x => new ShortAuthorBlm
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    }).ToList(),
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
                Name = dbBook.Name,
                YearOfIssue = dbBook.YearOfIssue,
                Authors = dbBook.Authors.Select(x => new ShortAuthorDataModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList()
            };
        }

        public void Update(BookPostBlm bookBlm)
        {
            Book bookMemberDb = new Book();
            //TODO: Make book unique
            if (bookBlm.Id==0) {
                bookMemberDb = _bookRepository.GetAll().First(x => x.Name == bookBlm.Name && x.YearOfIssue == bookBlm.YearOfIssue);
            }
            else
            {
                bookMemberDb.Id = bookBlm.Id;
                bookMemberDb.Name = bookBlm.Name;
                bookMemberDb.YearOfIssue = bookBlm.YearOfIssue;
            }
            ////bookMemberDb.Authors = bookBlm.Authors.Select(x => _authorRepository.Get(x.Id)).ToList();
            
            bookMemberDb.Authors = _authorRepository.GetAll().Where(x => bookBlm.Authors.Select(z => z.Id).Contains(x.Id)).ToList();

            _bookRepository.Update(bookMemberDb);
        }
    }
}
