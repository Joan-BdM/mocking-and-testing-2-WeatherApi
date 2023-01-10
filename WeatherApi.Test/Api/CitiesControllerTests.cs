using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;
using WeatherApi.Controllers;
using Xunit;

namespace WeatherApi.Test.Api
{
    public class CitiesControllerTests
    {
        private readonly ICityService _cityService;

        private readonly CitiesController _controller;

        private readonly Fixture _fixture = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public CitiesControllerTests()
        {
            _cityService = Substitute.For<ICityService>();

            _controller = new CitiesController(_cityService);
        }

        [Fact]
        public void GetAll_Ok()
        {
            // Arrange
            var expected = _fixture.CreateMany<CityDto>();

            _cityService.GetAll().Returns(expected);

            // Act
            var actual = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(expected, ((OkObjectResult)actual).Value);
        }

        [Fact]
        public void Get_Ok()
        {
            // Arrange
            var expected = _fixture.Create<CityDto>();

            _cityService.Get(Arg.Any<int>()).ReturnsForAnyArgs(expected);

            // Act
            var actual = _controller.Get(expected.Id);

            // Assert
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(expected, ((OkObjectResult)actual).Value);
        }

        [Fact]
        public void Get_NotFound()
        {
            // Arrange
            _cityService.Get(Arg.Any<int>()).ReturnsNullForAnyArgs();

            // Act
            var actual = _controller.Get(-1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actual);
        }
    }
}
