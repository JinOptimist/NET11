using BusinessLayerInterfaces.BusinessModels.Books;

namespace BusinessLayerInterfaces.BookServices
{
    public interface IBookServices
    {
        IEnumerable<BookGetBlm> GetAll();

        void Save(BookPostBlm bookBlm);

        void Remove(int id);
    }
}
