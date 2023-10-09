using DALInterfaces.Models.Movies;
using DALInterfaces.Models.RockHall;

namespace DALInterfaces.Models.Books
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
