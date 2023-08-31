using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DALEfDB
{
    public class Startup
    {
       public const string ConnectionString = @"Data Source=DESKTOP-IL8B3HF\SQLEXPRESS;Initial Catalog=GamerShop;Integrated Security=True;Pooling=False;TrustServerCertificate=true;";// public const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GamerShop;Trusted_Connection=True;";
        public void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<WebContext>(op => op
                .UseLazyLoadingProxies()
                .UseSqlServer(ConnectionString));
        }
    }
}
