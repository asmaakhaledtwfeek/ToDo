using APA.Infrastructure.Seeders;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Abstractions;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInfrastructureStrapping(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.DBSeedingAsync().Wait();

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            return services;
        }

        private static async Task<IServiceCollection> DBSeedingAsync(this IServiceCollection services)
        {
            services.AddScoped<ISeeder, ToDoItemSeeder>();

            using var serviceProvider = services.BuildServiceProvider();

            var seeders = serviceProvider.GetServices<ISeeder>();

            seeders = seeders.OrderBy(x => x.ExecutionOrder);

            foreach (var seeder in seeders)
                await seeder.SeedAsync();

            return services;
        }
    }
}
