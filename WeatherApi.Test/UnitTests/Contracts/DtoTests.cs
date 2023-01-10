using AutoFixture;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WeatherApi.Contracts.DTO;
using Xunit;

namespace WeatherApi.Test.UnitTests.Contracts
{
    public class DtoTests
    {
        private readonly Fixture _fixture = new();

        /// <summary>
        ///  Class types to be tested
        /// </summary>
        public static IEnumerable<object[]> TestTypes =>
            new List<object[]>
            {
                new object[] { typeof(CityDto) },
                new object[] { typeof(CurrentWeather) },
                new object[] { typeof(WeatherForecast) }
            };

        //[Theory]
        //[MemberData(nameof(TestTypes))]
        //public void Are_Equal<T>(T type)
        //{
        //    // Arrange
        //    var original = _fixture.Create(type, new AutoFixture.Kernel.SpecimenContext(_fixture));
        //    var copy = CreateDeepCopy(original);

        //    // Act
        //    // Assert
        //    Assert.True(original.Equals(copy));
        //    Assert.True(original.Equals(copy as object));
        //    Assert.Equal(original, copy);
        //    Assert.Equal(original.GetHashCode(), copy.GetHashCode());
        //}

        //[Theory]
        //[MemberData(nameof(TestTypes))]
        //public void Are_Different<T>(T type)
        //{
        //    // Arrange
        //    var object1 = _fixture.Create(type, new AutoFixture.Kernel.SpecimenContext(_fixture));
        //    var object2 = _fixture.Create(type, new AutoFixture.Kernel.SpecimenContext(_fixture));

        //    // Act
        //    // Assert
        //    Assert.False(object1.Equals(object2));
        //    Assert.False(object1.Equals((object)object2));
        //    Assert.NotEqual(object1, object2);
        //    Assert.NotEqual(object1.GetHashCode(), object2.GetHashCode());
        //}

        //[Theory]
        //[MemberData(nameof(TestTypes))]
        //public void Are_Different_Null<T>(T type)
        //{
        //    // Arrange
        //    var object1 = _fixture.Create(type, new AutoFixture.Kernel.SpecimenContext(_fixture));
        //    object object2 = null;

        //    // Act
        //    // Assert
        //    Assert.False(object1.Equals(object2));
        //    Assert.False(object1.Equals((object)object2));
        //    Assert.NotEqual(object1, object2);
        //}

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
