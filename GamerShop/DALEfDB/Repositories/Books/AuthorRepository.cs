using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace DALEfDB.Repositories.Books
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(WebContext context) : base(context) { }
    }
}
