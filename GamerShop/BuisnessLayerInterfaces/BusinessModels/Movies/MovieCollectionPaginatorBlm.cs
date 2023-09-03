namespace BusinessLayerInterfaces.BusinessModels.Movies;

public class MovieCollectionPaginatorBlm
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int Count { get; set; }
    public List<ShortMovieCollectionBlm> Collections { get; set; }
}