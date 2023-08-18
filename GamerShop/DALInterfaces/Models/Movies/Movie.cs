namespace DALInterfaces.Models.Movies;

public class Movie : BaseModel
{
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
}