using WeatherApi.Contracts.Infrastructure;
using WeatherApi.Models;

namespace WeatherApi.Infrastructure.Repositories
{
    public sealed class CityRepository : ICityRepository
    {
        /// <summary>
        /// City list
        /// </summary>
        private readonly List<City> _cityList = new()
        {
            new City { Id = 1, Name = "Palma", Latitude = 39.5700136f, Longitude = 2.6457357f },
            new City { Id = 2, Name = "Barcelona", Latitude = 41.3927755f, Longitude = 2.0701494f },
            new City { Id = 3, Name = "Madrid", Latitude = 40.4381311f, Longitude = -3.8196196f },
            new City { Id = 4, Name = "Berlin", Latitude = 52.5069704f, Longitude = 13.2846501f },
            new City { Id = 5, Name = "Tokio", Latitude = 35.4896467f, Longitude = 137.4695897f },
            new City { Id = 6, Name = "Los Angeles", Latitude = -37.4707f, Longitude = -72.3517f },
            new City { Id = 7, Name = "Ottawa", Latitude = 41.3532f, Longitude = -88.8306f },
            new City { Id = 8, Name = "Manhattan", Latitude = 40.7834f, Longitude = -73.9662f },
            new City { Id = 9, Name = "Honolulu", Latitude = 21.3294f, Longitude = -157.846f },
            new City { Id = 10, Name = "Sydney", Latitude = -33.865f, Longitude = 151.2094f }
        };

        /// <inheritdoc/>
        public IEnumerable<City> GetAll()
        {
            return _cityList;
        }

        /// <inheritdoc/>
        public City Get(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (_cityList.Any(x => x.Id == id))
                return _cityList.First(x => x.Id == id);

            // Not Found
            return null;
        }
    }
}