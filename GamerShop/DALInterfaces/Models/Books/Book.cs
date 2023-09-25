using DALInterfaces.Models.Movies;
using DALInterfaces.Models.RockHall;

namespace DALInterfaces.Models.Books
{
    public class Book : BaseModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int YearOfIssue { get; set; }
        public virtual ICollection<Movie> FilmAdaptations { get; set; }
    }
}
