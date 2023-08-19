namespace BusinessLayerInterfaces.BusinessModels.Movies;

public class GetMovieBlm
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DateCreated { get; set; }
    public string UserName { get; set; }
}