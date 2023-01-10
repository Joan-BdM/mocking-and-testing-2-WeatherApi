using System;
using System.Collections.Generic;
using WeatherApi.Infrastructure.Repositories;
using WeatherApi.Models;
using Xunit;

namespace WeatherApi.Test.UnitTests.Infrastructure
{
    public class CityRepositoryTests
    {
        private readonly CityRepository _sut;

        public CityRepositoryTests()
        {
            _sut = new CityRepository();
        }

        //[Fact]
        //public void GetAll_Ok()
        //{
        //    // Arrange
        //    var expected = new City { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f };

        //    // Act
        //    var actual = _sut.GetAll();

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.IsAssignableFrom<IEnumerable<City>>(actual);
        //    Assert.NotEmpty(actual);
        //    Assert.Contains(expected, actual);
        //}

        //[Fact]
        //public void Get_Ok()
        //{
        //    // Arrange
        //    var expected = new City { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f };

        //    // Act
        //    var actual = _sut.Get(expected.Id);

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.IsType<City>(actual);
        //    Assert.Equal(expected, actual);
        //}

        //[Fact]
        //public void Get_NotFound()
        //{
        //    // Arrange

        //    // Act
        //    var actual = _sut.Get(0);

        //    // Assert
        //    Assert.Null(actual);
        //}

        //[Fact]
        //public void Get_Exception()
        //{
        //    // Arrange
        //    // Act

        //    // Assert
        //    Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Get(-1));
        //}
    }
}
