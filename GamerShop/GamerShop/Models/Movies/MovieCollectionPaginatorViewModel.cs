using BusinessLayerInterfaces.BusinessModels.Movies;

namespace GamerShop.Models.Movies;

public class MovieCollectionPaginatorViewModel
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int Count { get; set; }
    public List<int> AvailablePages { get; set; }
    public List<ShowShortMovieCollectionViewModel> Collections { get; set; }
}