namespace BusinessLayerInterfaces.BusinessModels.Movies;

public class MovieBlm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
    public string Country { get; set; }
    public int Duration { get; set; }
    public string Genres { get; set; }
    public string FilmAdaptationOf { get; set; }
}