using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Contracts.DTO;
using Xunit;

namespace WeatherApi.Test.Api.IntegrationTests
{
    public class CitiesControllerIntegrationTests
    {
        readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public CitiesControllerIntegrationTests()
        {
            var application = new WebApplicationFactory<Program>();

            _client = application.CreateClient();
        }

        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var expected = new CityDto { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f };

            // Act
            HttpResponseMessage response = await _client.GetAsync("Cities/GetAll");

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsAsync<List<CityDto>>();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains(expected, result);
        }

        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            var expected = new CityDto { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f };

            // Act
            HttpResponseMessage response = await _client.GetAsync("Cities/Get/1");

            // Assert
            Assert.True(response.IsSuccessStatusCode);

            var result = await response.Content.ReadAsAsync<CityDto>();
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _client.GetAsync("Cities/Get/0");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
