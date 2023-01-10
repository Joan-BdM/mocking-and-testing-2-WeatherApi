using AutoFixture;
using AutoMapper;
using WeatherApi.Application.Profiles;
using WeatherApi.Contracts.DTO;
using WeatherApi.Models;
using Xunit;

namespace WeatherApi.Test.UnitTests.Application
{
    public class MapperTests
    {
        private readonly IMapper _mapper;

        private readonly Fixture _fixture = new();

        /// <summary>
        /// Constuctor
        /// </summary>
        public MapperTests()
        {
            // Confiiguramos el Mapper con los perfiles a usar
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CityProfile>());
            _mapper = config.CreateMapper();
        }

        //[Fact]
        //public void CityMap()
        //{
        //    // Arrange
        //    var original = _fixture.Create<City>();
        //    var expected = new CityDto
        //    {
        //        Id = original.Id,
        //        Name = original.Name,
        //        Latitude = original.Latitude,
        //        Longitude = original.Longitude
        //    };

        //    // Act
        //    var actual = _mapper.Map<CityDto>(original);

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.IsType<CityDto>(actual);
        //    Assert.Equal(expected, actual);
        //}

        //[Fact]
        //public void CityReverseMap()
        //{
        //    // Arrange
        //    var original = _fixture.Create<CityDto>();
        //    var expected = new City
        //    {
        //        Id = original.Id,
        //        Name = original.Name,
        //        Latitude = original.Latitude,
        //        Longitude = original.Longitude
        //    };

        //    // Act
        //    var actual = _mapper.Map<City>(original);

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.IsType<City>(actual);
        //    Assert.Equal(expected, actual);
        //}
    }
}
