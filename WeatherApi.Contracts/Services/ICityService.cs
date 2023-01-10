using WeatherApi.Contracts.DTO;

namespace WeatherApi.Contracts.Services
{
    public interface ICityService
    {
        /// <summary>
        /// Returns all the available cities
        /// </summary>
        IEnumerable<CityDto> GetAll();

        /// <summary>
        /// Get city detail by Id
        /// </summary>
        /// <param name="id">City Id filter</param>
        CityDto? Get(int id);
    }
}
