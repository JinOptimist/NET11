namespace DALInterfaces.Models.Recipe
{
    public class Recipe : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public int CookingTime { get; set; }

        public int PreparationTime { get; set; }

        public int Servings { get; set; }

        public string DifficultyLevel { get; set; }

        public string Cuisine { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual List<User> UsersWhoLikeIt { get; set; }
    }
}
