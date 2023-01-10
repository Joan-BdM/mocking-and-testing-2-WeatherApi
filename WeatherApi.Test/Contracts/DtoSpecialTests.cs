using AutoFixture;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WeatherApi.Contracts.DTO;
using Xunit;

namespace WeatherApi.Test.Contracts
{
    public class DtoSpecialTests
    {
        private readonly Fixture _fixture = new();

        public static IEnumerable<object[]> TestWeatherCodes =>
            new List<object[]>
            {
                new object[] { -1 },
                new object[] { 0 },
                new object[] { 1 },
                new object[] { 2 },
                new object[] { 3 },
                new object[] { 45 },
                new object[] { 48 },
                new object[] { 51 },
                new object[] { 53 },
                new object[] { 55 },
                new object[] { 56 },
                new object[] { 57 },
                new object[] { 61 },
                new object[] { 63 },
                new object[] { 65 },
                new object[] { 66 },
                new object[] { 67 },
                new object[] { 71 },
                new object[] { 73 },
                new object[] { 75 },
                new object[] { 77 },
                new object[] { 80 },
                new object[] { 81 },
                new object[] { 82 },
                new object[] { 85 },
                new object[] { 86 },
                new object[] { 95 },
                new object[] { 96 },
                new object[] { 99 },
                new object[] { 9999 }
            };

        [Fact]
        public void WeatherForecast_NullCity_Equal()
        {
            // Arrange
            var original = _fixture.Build<WeatherForecast>().Without(x => x.City).Create();
            var copy = CreateDeepCopy(original);

            // Act
            // Asser
            Assert.True(original.Equals(copy));
            Assert.True(original.Equals(copy as object));
            Assert.Equal(original, copy);
            Assert.Equal(original.GetHashCode(), copy.GetHashCode());
        }

        [Fact]
        public void WeatherForecast_NullCity_Different()
        {
            // Arrange
            var object1 = _fixture.Build<WeatherForecast>().Without(x => x.City).Create();
            var object2 = _fixture.Build<WeatherForecast>().Without(x => x.City).Create();

            // Act
            // Asser
            Assert.False(object1.Equals(object2));
            Assert.False(object1.Equals((object)object2));
            Assert.NotEqual(object1, object2);
            Assert.NotEqual(object1.GetHashCode(), object2.GetHashCode());
        }

        [Theory]
        [MemberData(nameof(TestWeatherCodes))]
        public void CurrentWeather_Description(int weatherCode)
        {
            // Arrange
            var sut = new CurrentWeather { Weathercode = weatherCode };

            // Act
            var result = sut.Description;

            // Assert
            Assert.NotNull(result);
        }

        /*
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(45)]
        [InlineData(48)]
        [InlineData(51)]
        [InlineData(53)]
        [InlineData(55)]
        [InlineData(56)]
        [InlineData(57)]
        [InlineData(61)]
        [InlineData(63)]
        [InlineData(65)]
        [InlineData(66)]
        [InlineData(67)]
        [InlineData(71)]
        [InlineData(73)]
        [InlineData(75)]
        [InlineData(77)]
        [InlineData(80)]
        [InlineData(81)]
        [InlineData(82)]
        [InlineData(85)]
        [InlineData(86)]
        [InlineData(95)]
        [InlineData(96)]
        [InlineData(99)]
        [InlineData(9999)]
        public void CurrentWeather_Description(int weatherCode)
        {
            // Arrange
            var sut = new CurrentWeather { Weathercode = weatherCode };

            // Act
            var result = sut.Description;

            // Assert
            Assert.NotNull(result);
        }
        */

        /// <summary>
        /// Creates a full deep copy of an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static T CreateDeepCopy<T>(T obj)
        {
            using var ms = new MemoryStream();

            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);

            return (T)serializer.Deserialize(ms);
        }
    }
}
