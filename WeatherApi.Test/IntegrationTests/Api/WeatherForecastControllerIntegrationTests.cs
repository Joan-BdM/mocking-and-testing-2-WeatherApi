using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Contracts.DTO;
using Xunit;

namespace WeatherApi.Test.IntegrationTests.Api
{
    public class WeatherForecastControllerIntegrationTests
    {
        readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public WeatherForecastControllerIntegrationTests()
        {
            var application = new WebApplicationFactory<Program>();

            _client = application.CreateClient();
        }

        //[Fact]
        //public async Task Get_Ok()
        //{
        //    // Arrange
        //    var expected = new CityDto { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f };

        //    // Act
        //    HttpResponseMessage response = await _client.GetAsync("WeatherForecast/Get/1");

        //    // Assert
        //    Assert.True(response.IsSuccessStatusCode);

        //    var result = await response.Content.ReadAsAsync<WeatherForecast>();
        //    Assert.NotNull(result);
        //    Assert.NotNull(result.Current_weather);
        //    Assert.Equal(expected, result.City);
        //}

        //[Fact]
        //public async Task Get_NotFound()
        //{
        //    // Arrange

        //    // Act
        //    HttpResponseMessage response = await _client.GetAsync("WeatherForecast/Get/0");

        //    // Assert
        //    Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        //}
    }
}
