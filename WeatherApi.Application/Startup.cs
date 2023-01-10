using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WeatherApi.Application.Services;
using WeatherApi.Contracts.Services;
using WeatherApi.Infrastructure;

namespace WeatherApi.Application
{
    /// <summary>
    /// Register all the Applications Services and their dependencies
    /// </summary>
    public static class Startup
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IOpenMeteoService, OpenMeteoService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();

            // Dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructureLayer();
        }
    }
}
