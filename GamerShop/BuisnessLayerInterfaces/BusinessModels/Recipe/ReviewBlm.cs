namespace BusinessLayerInterfaces.BusinessModels.Recipe
{
    public class ReviewBlm
    {
        public int RecipeId { get; set; }

        public int UserId { get; set; }

        public double Rating { get; set; }
        
        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
