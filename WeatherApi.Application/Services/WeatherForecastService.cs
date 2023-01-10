using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ICityService _cityService;
        private readonly IOpenMeteoService _openMeteoService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public WeatherForecastService(ICityService service, IOpenMeteoService openMeteoService)
        {
            _cityService = service;
            _openMeteoService = openMeteoService;
        }

        /// <inheritdoc/>
        public async Task<WeatherForecast> Get(int cityId)
        {
            // Get City info
            CityDto city = _cityService.Get(cityId);

            if (city == null)
                return null;

            // Call for forecast
            WeatherForecast result = await _openMeteoService.Get(city.Latitude, city.Longitude);

            result.City = city;

            return result;
        }
    }
}