using DALInterfaces.DataModels;
using DALInterfaces.DataModels.Books;
using DALInterfaces.DataModels.PcBuild;
using DALInterfaces.Models.Books;
using DALInterfaces.Repositories.Books;

namespace DALEfDB.Repositories.Books
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(WebContext context) : base(context)
        {
        }

        public PaginatorDataModel<BookDataModel> GetBookPaginatorDataModel(int page, int perPage)
        {
            var count = _dbSet.Count();

            var books = _dbSet
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(dbBook => new BookDataModel()
                {
                    Id = dbBook.Id,
                    Name = dbBook.Name,
                    YearOfIssue = dbBook.YearOfIssue,
                    Authors = dbBook.Authors.Select(x => new ShortAuthorDataModel
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    }).ToList()
                })
                .ToList();

            return new PaginatorDataModel<BookDataModel>()
            {
                Count = count,
                Page = page,
                PerPage = perPage,
                Items = books
            };
        }
    }
}
