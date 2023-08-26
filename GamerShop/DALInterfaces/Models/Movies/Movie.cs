namespace DALInterfaces.Models.Movies;

public class Movie : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
    public string Country { get; set; }
    public int Duration { get; set; }

    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Collection> Collections { get; set; }
}