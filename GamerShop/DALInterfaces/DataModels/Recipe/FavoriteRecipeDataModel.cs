using DALInterfaces.Models;

namespace DALInterfaces.DataModels.Recipe
{
    public class FavoriteRecipeDataModel
    {
        public User User { get; set; }

        public Models.Recipe.Recipe Recipe { get; set; }
    }
}
