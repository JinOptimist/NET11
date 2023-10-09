using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.Common;

namespace BusinessLayerInterfaces.BookServices
{
    public interface IBookServices: IPaginatorServices<BookGetBlm>
    {
        IEnumerable<BookGetBlm> GetAll();

        void Save(BookPostBlm bookBlm);

        void Remove(int id);
    }
}
