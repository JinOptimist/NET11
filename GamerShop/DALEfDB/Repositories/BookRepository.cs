using DALInterfaces.Models.Books;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(WebContext context) : base(context)
        {
        }
    }
}
