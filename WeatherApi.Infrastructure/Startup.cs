using Microsoft.Extensions.DependencyInjection;
using WeatherApi.Contracts.Infrastructure;
using WeatherApi.Infrastructure.Repositories;

namespace WeatherApi.Infrastructure
{
    public static class Startup
    {
        /// <summary>
        /// Register all the Infrasturcure Repositories and their dependencies
        /// </summary>
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            // Repositories
            services.AddTransient<ICityRepository, CityRepository>();
        }
    }
}
