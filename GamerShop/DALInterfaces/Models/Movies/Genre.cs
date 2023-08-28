namespace DALInterfaces.Models.Movies;

public class Genre : BaseModel
{
    public string Name { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }
}