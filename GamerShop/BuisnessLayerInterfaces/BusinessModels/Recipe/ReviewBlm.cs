namespace BusinessLayerInterfaces.BusinessModels.Recipe
{
    public class ReviewBlm
    {
        public int RecipeId { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public double Rating { get; set; }
        
        public string Text { get; set; }

        public string Date { get; set; }
    }
}
