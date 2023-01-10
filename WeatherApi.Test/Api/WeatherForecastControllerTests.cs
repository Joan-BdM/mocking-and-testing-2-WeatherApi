using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Threading.Tasks;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;
using WeatherApi.Controllers;
using Xunit;

namespace WeatherApi.Test.Api
{
    public class WeatherForecastControllerTests
    {
        private readonly IWeatherForecastService _weatherService;

        private readonly WeatherForecastController _controller;

        private readonly Fixture _fixture = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public WeatherForecastControllerTests()
        {
            _weatherService = Substitute.For<IWeatherForecastService>();

            _controller = new WeatherForecastController(_weatherService);
        }

        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            var expected = _fixture.Create<WeatherForecast>();

            _weatherService.Get(Arg.Any<int>()).ReturnsForAnyArgs(expected);

            // Act
            var actual = await _controller.Get(expected.City.Id);

            // Assert
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(expected, ((OkObjectResult)actual).Value);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            // Arrange
            _weatherService.Get(Arg.Any<int>()).ReturnsNullForAnyArgs();

            // Act
            var actual = await _controller.Get(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actual);
        }
    }
}
