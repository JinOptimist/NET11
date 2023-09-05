using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.UserServices;
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
    }
}
