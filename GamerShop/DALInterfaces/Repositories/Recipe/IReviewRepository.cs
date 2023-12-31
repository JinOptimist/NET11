﻿using DALInterfaces.Models.Recipe;

namespace DALInterfaces.Repositories.Recipe
{
	public interface IReviewRepository : IBaseRepository<Review>
	{
        IEnumerable<Review> GetRecipeReviews(int recipeId);
    }
	
}