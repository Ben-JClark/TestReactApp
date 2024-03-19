using Microsoft.AspNetCore.Mvc;

namespace TestReactApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("short", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return GenerateWeatherForcasts(5);
        }

        [HttpGet("extended", Name = "GetExtendedWeatherForecast")]
        public IEnumerable<WeatherForecast> GetExtended()
        {
            IEnumerable<WeatherForecast>  WeatherForecast = GenerateWeatherForcasts(10);
            return WeatherForecast;
        }

        private IEnumerable<WeatherForecast> GenerateWeatherForcasts(int count)
        {
            Random rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}
