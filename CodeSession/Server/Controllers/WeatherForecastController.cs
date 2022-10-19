using CodeSession.Server.Services;
using CodeSession.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CodeSession.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.CreateForecasts(5);
        }
    }
}