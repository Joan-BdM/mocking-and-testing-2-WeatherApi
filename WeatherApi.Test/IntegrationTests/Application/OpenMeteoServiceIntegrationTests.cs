using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WeatherApi.Application.Services;
using WeatherApi.Contracts.DTO;
using Xunit;

namespace WeatherApi.Test.IntegratinoTests.Application
{
    public class OpenMeteoServiceIntegrationTests
    {
        private readonly IConfiguration _configuration;

        private readonly OpenMeteoService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        public OpenMeteoServiceIntegrationTests()
        {
            // Load local Appsettings.json
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            _service = new OpenMeteoService(_configuration);
        }

        //[Theory]
        //[InlineData(0, 0)]
        //[InlineData(39.57, 2.65)]
        //[InlineData(35.49, 137.47)]
        //public async Task Get_Ok(float lat, float lon)
        //{
        //    // Arrange

        //    // Act
        //    var actual = await _service.Get(lat, lon);

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.IsType<WeatherForecast>(actual);
        //    Assert.NotNull(actual.Current_weather);
        //}
    }
}
