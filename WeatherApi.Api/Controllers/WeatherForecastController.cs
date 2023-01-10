using Microsoft.AspNetCore.Mvc;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet("Get/{cityId}")]
        public async Task<IActionResult> Get(int cityId)
        {
            WeatherForecast result = await _service.Get(cityId);

            if (result == null)
                return NotFound("City Not Found");

            return Ok(result);
        }
    }
}