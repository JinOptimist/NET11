using DALInterfaces.Models.Books;

namespace DALInterfaces.DataModels.Books
{
    public class BookDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public ICollection<ShortAuthorDataModel> Authors { get; set; }
    }
}
