namespace DALInterfaces.DataModels.Movies;

public class ShortMovieCollectionDataModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public double Rating { get; set; }
}