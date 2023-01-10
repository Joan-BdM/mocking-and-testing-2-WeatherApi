using AutoMapper;
using WeatherApi.Contracts.DTO;
using WeatherApi.Models;

namespace WeatherApi.Application.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
