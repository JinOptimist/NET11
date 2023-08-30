using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Recipe
{
    public class ReviewViewModel
    {
        [Display(Name = "Rating")]
	    [Range(1, 5, ErrorMessage = "Rating must be from 1 to 5 stars")]
		public double Rating { get; set; }

		[Required(ErrorMessage = "ReviewText is required.")]
		[StringLength(250, ErrorMessage = "ReviewText cannot exceed 250 characters.")]
		public string Text { get; set; }

		public DateTime Date { get; set; }
											
		public int RecipeId { get; set; }
	}
}
