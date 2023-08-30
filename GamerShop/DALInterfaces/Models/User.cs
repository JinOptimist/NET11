using DALInterfaces.Models.PcBuild;

using DALInterfaces.Models.Movies;

namespace DALInterfaces.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public virtual Movie? FavoriteMovie { get; set; }

        public virtual List<Recipe.Recipe> FavoriteRecipes { get; set; }
        public virtual ICollection<Build>? CreatedBuilds { get; set; }
        public virtual ICollection<Build>? LikedBuilds { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
