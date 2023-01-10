using Microsoft.AspNetCore.Mvc;
using WeatherApi.Contracts.DTO;
using WeatherApi.Contracts.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public CitiesController(ICityService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            CityDto result = _service.Get(id);

            if (result == null)
                return NotFound("City Not Found");

            return Ok(result);
        }
    }
}