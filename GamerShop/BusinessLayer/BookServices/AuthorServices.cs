using BusinessLayerInterfaces.BookServices;
using BusinessLayerInterfaces.BusinessModels.Books;
using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace BusinessLayer.BookServices
{
    public class AuthorServices : IAuthorServices
    {
        private IAuthorRepository _authorRepository;

        public AuthorServices(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
                    Books = dbMember.Books.Select(x => new ShortBookBlm
                    {
                        Id=x.Id,
                        Name=x.Name,
                        Authors=x.Authors.Select(a=> new ShortAuthorBlm
                        {
                            Id = a.Id,
                            FirstName=a.FirstName,
                            LastName=a.LastName,
                        }).ToList()
                    }).ToList(),
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
                Books = authorBlm.Books.Select(x => new Book
                {
                    Id = x.Id,
                    Name = x.Name,
                    Authors = x.Authors.Select(a => new Author
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                    }).ToList()
                }).ToList(),
            };
            _authorRepository.Save(bookMemberDb);
        }
    }
}
