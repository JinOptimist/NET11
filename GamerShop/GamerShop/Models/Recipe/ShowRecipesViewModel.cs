﻿namespace GamerShop.Models.Recipe
{
    public class ShowRecipesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public int CookingTime { get; set; }

        public int PreparationTime { get; set; }

        public int Servings { get; set; }

        public string DifficultyLevel { get; set; }

        public string Cuisine { get; set; }

        public bool IsFavorite { get; set; }

		public List<DisplayReviewViewModel> Reviews { get; set; }
	}
}
