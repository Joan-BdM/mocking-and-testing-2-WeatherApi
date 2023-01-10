using WeatherApi.Contracts.DTO;

namespace WeatherApi.Contracts.Services
{
    public interface IWeatherForecastService
    {
        /// <summary>
        /// Gets a single Forecast by it's Id
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<WeatherForecast> Get(int cityId);
    }
}
