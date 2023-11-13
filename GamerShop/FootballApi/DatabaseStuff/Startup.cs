using Microsoft.EntityFrameworkCore;

namespace FootballApi.DatabaseStuff
{
    public class Startup
    {
        public const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FootballApi;Trusted_Connection=True;";
        public void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<FootbalLApiContext>(op => op
                .UseLazyLoadingProxies()
                .UseSqlServer(ConnectionString));
        }
    }
}
