namespace BusinessLayerInterfaces.BusinessModels.Movies;

public class CollectionBlmForShow
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public string AuthorName { get; set; }
    public ICollection<ShortMovieBlm> Movies { get; set; }
    public double Rating { get; set; }
}