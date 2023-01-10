using System.Threading.Tasks;
using WeatherApi.Application.Services;
using Xunit;

namespace WeatherApi.Test.Application.IntegratinoTests
{
    public class OpenMeteoServiceIntegrationTests
    {
        private readonly OpenMeteoService _service = new();

        [Theory]
        [InlineData(0, 0)]
        [InlineData(39.57, 2.65)]
        [InlineData(35.49, 137.47)]
        public async Task Get_Ok(float lat, float lon)
        {
            // Arrange

            // Act
            var actual = await _service.Get(lat, lon);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Current_weather);
        }
    }
}
