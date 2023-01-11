using Microsoft.Extensions.Configuration;
using System.Globalization;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Application.Services
{
    public class OpenMeteoService : IOpenMeteoService
    {
        private const string SERVICE_URL = "OpenMeteoEndpoint";

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public OpenMeteoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<WeatherForecast> Get(float latitude, float longitude)
        {
            string enpoint = _configuration[SERVICE_URL];

            // Parse endpoint with invariant culture for float "." instead of ","
            string endpoint = string.Format(enpoint, latitude.ToString(CultureInfo.InvariantCulture), longitude.ToString(CultureInfo.InvariantCulture));

            // Http request
            var client = new HttpClient();
            var response = await client.GetAsync(endpoint);

            WeatherForecast result = await response.Content.ReadAsAsync<WeatherForecast>();

            return result;
        }
    }
}
