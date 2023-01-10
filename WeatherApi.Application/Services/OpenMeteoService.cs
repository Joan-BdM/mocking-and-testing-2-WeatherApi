using System.Globalization;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Application.Services
{
    public class OpenMeteoService : IOpenMeteoService
    {
        private const string SERVICE_URL = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true";

        /// <inheritdoc/>
        public async Task<WeatherForecast> Get(float latitude, float longitude)
        {
            // Parse endpoint with invariant culture for float "." instead of ","
            string endpoint = string.Format(SERVICE_URL, latitude.ToString(CultureInfo.InvariantCulture), longitude.ToString(CultureInfo.InvariantCulture));

            // Http request
            var client = new HttpClient();
            var response = await client.GetAsync(endpoint);

            WeatherForecast result = await response.Content.ReadAsAsync<WeatherForecast>();

            return result;
        }
    }
}
