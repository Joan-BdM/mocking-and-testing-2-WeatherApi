using WeatherApi.Contracts.DTO;

namespace WeatherApi.Contracts.Services
{
    public interface IOpenMeteoService
    {
        /// <summary>
        /// Calls Open-Meteo to retrive a Weather Forecast for the given Lat and Long
        /// </summary>
        Task<WeatherForecast> Get(float latitude, float longitude);
    }
}
