using AngleSharp.Io;
using DALEfDB.Repositories;
using DALInterfaces.Repositories;
using System.Reflection;

namespace GamerShop.Services
{
    public static class AutoDiResolver
    {
        public static void AutoRepositoryResolve(this IServiceCollection services)
        {
            var baseRepositoryInterface = typeof(IBaseRepository<>);
            var baseRepositoryClass = typeof(BaseRepository<>);

            var typeFromBaseRepositoryClass =
                Assembly
                    .GetAssembly(baseRepositoryClass)
                    ?.GetTypes();

            Assembly
                .GetAssembly(baseRepositoryInterface)
                ?.GetTypes()
                .Where(someType => someType.IsInterface
                    && someType.GetInterfaces()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == baseRepositoryInterface)
                )
                .ToList()
                .ForEach(repositoryInterface => // repositoryInterface == typeof(IBookRepository)
                {
                    var repository = typeFromBaseRepositoryClass
                        .First(x => x.GetInterfaces().Any(i => i == repositoryInterface));
                    //repository == typeof(BookRepository)
                    services.AddScoped(repositoryInterface, repository);
                });
        }
    }
}
