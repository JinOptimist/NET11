namespace DALInterfaces.Models.Movies;

public class Rating : BaseModel
{
    public int Value { get; set; }

    public int UserId { get; set; }
    public int CollectionId { get; set; }

    public virtual User User { get; set; }
    public virtual Collection Collection { get; set; }
}