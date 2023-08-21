namespace DALInterfaces.Models;

public class Movie : BaseModel
{
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }

    public virtual ICollection<User> UsersWhoLikeIt { get; set; }
}