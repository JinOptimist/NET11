using DALInterfaces.Models;
using DALInterfaces.Models.Recipe;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Models.Movies;
using Microsoft.EntityFrameworkCore;
using DALInterfaces.Models.Football;

namespace DALEfDB
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<RockMember> RockMembers { get; set; }

        public DbSet<Hero> Heros { get; set; }

        public DbSet<FootballClub> FootballClubs { get; set; }

        public DbSet<Processor> Processors { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Ssd> Ssds { get; set; }
        public DbSet<Hdd> Hddss { get; set; }
        public DbSet<Psu> Psus { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<FootballLeague> FootballLeagues { get; set; }

        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Startup.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(movie => movie.Genres)
                .WithMany(genre => genre.Movies);

            modelBuilder.Entity<User>()
                .HasMany(x => x.CreatedBuilds)
                .WithOne(x => x.Creator);

            modelBuilder.Entity<User>()
                .HasMany(x => x.FavoriteRecipes)
                .WithMany(x => x.UsersWhoLikeIt);

            modelBuilder.Entity<Build>()
                .HasMany(x => x.UsersWhoLikeIt)
                .WithMany(x => x.LikedBuilds);

            modelBuilder.Entity<FootballLeague>()
                .HasMany(footclubs => footclubs.footballClubs)
                .WithOne(footleagues => footleagues.League);
            
            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.CreatedFootballClubs)
            //    .WithOne(x => x.UserCreator);
            
            //modelBuilder.Entity<User>()
            //    .HasMany(x=>x.CreatedFootballLeagues)
            //    .WithOne(x => x.UserCreator);



        }
    }
}
