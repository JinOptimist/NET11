using DALInterfaces.Models;
using DALInterfaces.Models.Movies;
using DALInterfaces.Models.PcBuild;
using Microsoft.EntityFrameworkCore;

namespace DALEfDB
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Processor> Processors => Set<Processor>();
        public DbSet<Motherboard> Motherboards => Set<Motherboard>();
        public DbSet<GPU> GPUs => Set<GPU>();
        public DbSet<RAM> RAMs => Set<RAM>();
        public DbSet<SSD> SSDs => Set<SSD>();
        public DbSet<HDD> HDDs => Set<HDD>();
        public DbSet<PSU> PSUs => Set<PSU>();
        public DbSet<Cooler> Coolers => Set<Cooler>();
        public DbSet<Case> Cases => Set<Case>();
        public DbSet<Build> Builds => Set<Build>();

        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
        }
    }
}
