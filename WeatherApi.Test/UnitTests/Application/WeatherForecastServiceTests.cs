using AutoFixture;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Threading.Tasks;
using WeatherApi.Application.Services;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;
using Xunit;

namespace WeatherApi.Test.UnitTests.Application
{
    public class WeatherForecastServiceTests
    {
        private readonly ICityService _cityService;
        private readonly IOpenMeteoService _openMeteoService;

        private readonly WeatherForecastService _service;

        private readonly Fixture _fixture = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public WeatherForecastServiceTests()
        {
            _cityService = Substitute.For<ICityService>();
            _openMeteoService = Substitute.For<IOpenMeteoService>();

            _service = new WeatherForecastService(_cityService, _openMeteoService);
        }

        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            var expectedCity = _fixture.Create<CityDto>();
            var expectedForecast = _fixture.Build<WeatherForecast>()
                                    .With(x => x.City, expectedCity)
                                    .Create();

            _cityService.Get(Arg.Any<int>()).Returns(expectedCity);
            _openMeteoService.Get(Arg.Any<float>(), Arg.Any<float>()).Returns(expectedForecast);

            // Act
            var actual = await _service.Get(1);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<WeatherForecast>(actual);
            Assert.Equal(expectedForecast, actual);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            // Arrange
            _cityService.Get(Arg.Any<int>()).ReturnsNull();

            // Act
            var actual = await _service.Get(1);

            // Assert
            Assert.Null(actual);
        }
    }
}
