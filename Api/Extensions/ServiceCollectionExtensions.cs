using Services.DataAccess;

namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var repositoryTypes = typeof(IRepository<,>)
                .Assembly.GetTypes()
                .Where(t => t.IsRepository());

            foreach (var type in repositoryTypes)
            {
                services.AddScoped(type);
            }

            return services;
        }

        private static bool IsRepository(this Type type)
        {
            var implementsInterface = type.GetInterfaces()
                .Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<,>)
                );

            return implementsInterface && !type.IsAbstract;
        }
    }
}
