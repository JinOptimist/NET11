using DALInterfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Hero> Heros { get; set; }

        public DbSet<FootballClub> FootballClubs { get; set; }


        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
        }
    }
}
