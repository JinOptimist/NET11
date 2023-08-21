using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALEfDB.Repositories
{
	public class MovieRepository : BaseRepository<Movie>, IMovieRepository
	{
		public MovieRepository(WebContext context) : base(context)
		{
		}

		public override void Remove(int id)
		{
			var movie = _dbSet.First(x => x.Id == id);
			movie
				.UsersWhoLikeIt
				.ToList()
				.ForEach(x => movie.UsersWhoLikeIt.Remove(x));

			base.Remove(id);
		}

		public void ChooseFavorite(int currentUserId, int movieId)
		{
			var movie = _dbSet.First(x => x.Id == movieId);

			var user = _context.Users.First(x => x.Id == currentUserId);

			movie.UsersWhoLikeIt.Add(user);

			_context.SaveChanges();
		}
	}
}
