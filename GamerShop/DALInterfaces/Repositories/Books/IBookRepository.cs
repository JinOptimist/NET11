using DALInterfaces.DataModels;
using DALInterfaces.DataModels.Books;
using DALInterfaces.DataModels.PcBuild;
using DALInterfaces.Models;
using DALInterfaces.Models.Books;

namespace DALInterfaces.Repositories.Books
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        PaginatorDataModel<BookDataModel> GetBookPaginatorDataModel(int page, int perPage);
    }
}
