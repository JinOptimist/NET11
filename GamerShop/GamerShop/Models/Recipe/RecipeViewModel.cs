using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamerShop.Models.Recipe
{
    public class RecipeViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Instructions are required.")]
        public string Instructions { get; set; }

        [Display(Name = "Cooking Time (minutes)")]
        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be at least 1 minute.")]
        public int CookingTime { get; set; }

        [Display(Name = "Preparation Time (minutes)")]
        [Range(1, int.MaxValue, ErrorMessage = "Preparation time must be at least 1 minute.")]
        public int PreparationTime { get; set; }

        [Display(Name = "Number of Servings")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of servings must be at least 1.")]
        public int Servings { get; set; }

        [Display(Name = "Difficulty Level")]
        public string DifficultyLevel { get; set; }

        [Display(Name = "Cuisine")]
        public string Cuisine { get; set; }

        /*public int RecipeId { get; set; }

		[Required(ErrorMessage = "Ingredients are required.")]
		public List<string> Ingredients { get; set; }

		[Display(Name = "Total Time (minutes)")]
		public int TotalTime => CookingTime + PreparationTime;
		[Display(Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(Name = "Created By")]
		public string CreatedByUserId { get; set; }

		[Display(Name = "Created On")]
		public DateTime CreatedOn { get; set; }*/
    }
}
