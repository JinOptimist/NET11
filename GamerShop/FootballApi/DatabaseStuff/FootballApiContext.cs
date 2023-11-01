using FootballApi.DatabaseStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.DatabaseStuff
{
    public class FootbalLApiContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<League> Leagues { get; set; }

        public FootbalLApiContext(DbContextOptions<FootbalLApiContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Startup.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<League>()
                .HasMany(clubs => clubs.Clubs)
                .WithOne(leagues => leagues.League);
        }
    }
}
