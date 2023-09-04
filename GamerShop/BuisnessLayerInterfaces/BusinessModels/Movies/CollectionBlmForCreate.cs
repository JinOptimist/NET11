using DALInterfaces.Models;

namespace BusinessLayerInterfaces.BusinessModels.Movies;

public class CollectionBlmForCreate
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public UserBlm Author { get; set; }
    public ICollection<int> MoviesIds { get; set; }

}