namespace DALInterfaces.Models.Movies;

public class Collection : BaseModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }

    public int AuthorId { get; set; }

    public virtual User Author { get; set; }
    public virtual ICollection<Movies.Movie> Movies { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; }
}