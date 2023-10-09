using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels.Books;
using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace BusinessLayer.BookServices
{
    public class AuthorServices : IAuthorServices
    {
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;

        public AuthorServices(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }
        public IEnumerable<AuthorBlm> GetAll()
            => _authorRepository.GetAll().Select(dbMember
                => new AuthorBlm
                {
                    Id = dbMember.Id,
                    FirstName = dbMember.FirstName,
                    LastName = dbMember.LastName,
                    YearOfBirth = dbMember.YearOfBirth,
                    YearOfDeath = dbMember.YearOfDeath,
                    BooksIds = dbMember.Books.Select(x => x.Id).ToList(),
                }).ToList();

        public void Remove(int id)
        {
            _authorRepository.Remove(id);
        }

        public void Save(AuthorBlm authorBlm)
        {
            var bookMemberDb = new Author()
            {
                Id = authorBlm.Id,
                FirstName = authorBlm.FirstName,
                LastName = authorBlm.LastName,
                YearOfBirth = authorBlm.YearOfBirth,
                YearOfDeath = authorBlm.YearOfDeath,
                Books = 
            };
            _authorRepository.Save(bookMemberDb);
        }
    }
}
