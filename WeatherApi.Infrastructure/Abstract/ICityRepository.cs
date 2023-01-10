using WeatherApi.Models;

namespace WeatherApi.Contracts.Infrastructure
{
    public interface ICityRepository
    {
        /// <summary>
        /// Returns all the available cities
        /// </summary>
        IEnumerable<City> GetAll();

        /// <summary>
        /// Get city detail by Id
        /// </summary>
        /// <param name="id">City Id filter</param>
        City Get(int id);
    }
}
