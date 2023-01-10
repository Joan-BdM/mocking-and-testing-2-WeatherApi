using AutoMapper;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Infrastructure;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cityRepo"></param>
        public CityService(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IEnumerable<CityDto> GetAll()
        {
            var result = _cityRepo.GetAll();

            return _mapper.Map<IEnumerable<CityDto>>(result);
        }

        /// <inheritdoc/>
        public CityDto? Get(int id)
        {
            try
            {
                var result = _cityRepo.Get(id);

                if (result is not null)
                    return _mapper.Map<CityDto>(result);
            }
            catch
            {
                // TODO: log error
            }

            return null;
        }
    }
}
