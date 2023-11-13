using BusinessLayerInterfaces.BusinessModels;
using BusinessLayerInterfaces.BusinessModels.Books;
using BusinessLayerInterfaces.Common;
using DALInterfaces.Models;

namespace BusinessLayerInterfaces.BookServices
{
    public interface IBookServices: IPaginatorServices<BookGetBlm, Book>
    {
        IEnumerable<BookGetBlm> GetAll();

        void Save(BookPostBlm bookBlm);
        void Update(BookPostBlm bookBlm);

        void Remove(int id);
    }
}
