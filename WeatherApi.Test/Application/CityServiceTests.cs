using AutoFixture;
using AutoMapper;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using WeatherApi.Application.Profiles;
using WeatherApi.Application.Services;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Infrastructure;
using WeatherApi.Models;
using Xunit;

namespace WeatherApi.Test.Application
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

            // Confiiguramos el Mapper con los perfiles a usar
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CityProfile>());
            _mapper = config.CreateMapper();

            // Instanciamos el SUT
            _sut = new CityService(_cityRepo, _mapper);
        }

        [Fact]
        public void GetAll_Ok()
        {
            // Arrange
            var model = _fixture.CreateMany<City>();
            var expected = _mapper.Map<IEnumerable<CityDto>>(model);

            _cityRepo.GetAll().Returns(model);

            // Act
            var actual = _sut.GetAll();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Ok()
        {
            // Arrange
            var model = _fixture.Create<City>();
            var expected = _mapper.Map<CityDto>(model);

            _cityRepo.Get(Arg.Any<int>()).ReturnsForAnyArgs(model);

            // Act
            var actual = _sut.Get(model.Id);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_NotFound()
        {
            // Arrange
            _cityRepo.Get(Arg.Any<int>()).ReturnsNullForAnyArgs();

            // Act
            var actual = _sut.Get(0);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Get_Exception()
        {
            // Arrange
            _cityRepo.Get(Arg.Any<int>()).ReturnsNullForAnyArgs();

            // Act
            var actual = _sut.Get(-42);

            // Assert
            Assert.Null(actual);
        }
    }
}