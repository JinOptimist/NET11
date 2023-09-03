namespace DALInterfaces.DataModels.Movies;

public class MovieCollectionPaginatorDataModel
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int Count { get; set; }
    public List<ShortMovieCollectionDataModel> Collections { get; set; }
}