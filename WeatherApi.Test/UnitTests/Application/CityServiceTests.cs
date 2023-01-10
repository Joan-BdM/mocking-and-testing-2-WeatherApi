using AutoFixture;
using AutoMapper;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Linq;
using WeatherApi.Application.Services;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Infrastructure;
using WeatherApi.Models;
using Xunit;

namespace WeatherApi.Test.UnitTests.Application
{
    public class CityServiceTests
    {
        private readonly CityService _sut;
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;

        private readonly Fixture _fixture = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public CityServiceTests()
        {
            // Mockeamos la dependencia 
            _cityRepo = Substitute.For<ICityRepository>();
            _mapper = Substitute.For<IMapper>();

            // Instanciamos el SUT
            _sut = new CityService(_cityRepo, _mapper);
        }

        [Fact]
        public void GetAll_Ok()
        {
            // Arrange
            var model = _fixture.CreateMany<City>();
            var expected = model.Select(x => new CityDto
            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });

            _cityRepo.GetAll().Returns(model);
            _mapper.Map<IEnumerable<CityDto>>(Arg.Any<IEnumerable<City>>()).Returns(expected);

            // Act
            var actual = _sut.GetAll();

            // Assert
            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Ok()
        {
            // Arrange
            var model = _fixture.Create<City>();
            var expected = new CityDto
            {
                Id = model.Id,
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            _cityRepo.Get(Arg.Any<int>()).Returns(model);
            _mapper.Map<CityDto>(Arg.Any<City>()).Returns(expected);

            // Act
            var actual = _sut.Get(model.Id);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<CityDto>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_NotFound()
        {
            // Arrange
            _cityRepo.Get(Arg.Any<int>()).ReturnsNull();

            // Act
            var actual = _sut.Get(0);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Get_Exception()
        {
            // Arrange
            _cityRepo.Get(Arg.Any<int>()).ReturnsNull();

            // Act
            var actual = _sut.Get(-42);

            // Assert
            Assert.Null(actual);
        }
    }
}