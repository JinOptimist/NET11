namespace GamerShop.Models.Recipe
{
    public class ShowRecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public int CookingTime { get; set; }

        public int PreparationTime { get; set; }

        public int Servings { get; set; }

        public string DifficultyLevel { get; set; }

        public string Cuisine { get; set; }

        public bool IsFavorite { get; set; }

        public ReviewViewModel NewReview { get; set; } = new();

		public List<DisplayReviewViewModel> Reviews { get; set; }
	}
}
