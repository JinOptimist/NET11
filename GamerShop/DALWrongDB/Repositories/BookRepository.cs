using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
    }
}
