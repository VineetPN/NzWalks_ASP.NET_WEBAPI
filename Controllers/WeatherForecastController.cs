using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyApiProjectTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetWeather()
        {
            return Ok(new[] { "Sunny", "Rainy", "Moony" });
        }
    }
}
