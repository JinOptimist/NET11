using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace DALEfDB.Repositories.Books
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(WebContext context) : base(context)
        {
        }
    }
}
