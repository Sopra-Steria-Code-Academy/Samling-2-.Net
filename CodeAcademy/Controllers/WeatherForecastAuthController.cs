using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeAcademy.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastAuthController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastAuthController> _logger;

        public WeatherForecastAuthController(ILogger<WeatherForecastAuthController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetAuthWeatherForecast")]
        [SwaggerOperation(
            Summary = "Get the current weather forecast",
            Description = "Requires admin privileges",
            OperationId = "GetAuthWeatherForecast",
            Tags = new[] { "Orders", "SecondTag" }
        )]
        [SwaggerResponse(200, "Perfection", typeof(WeatherForecast))]
        [SwaggerResponse(401, "Naaah")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet(Name = "GetAuthWeatherForecastById")]
        [SwaggerOperation(
            Summary = "Get the current weather forecast",
            Description = "Requires admin privileges",
            OperationId = "GetAuthWeatherForecastById",
            Tags = new[] { "FirstTag", "SecondTag" }
        )]
        [SwaggerResponse(200, "Perfection", typeof(WeatherForecast))]
        [SwaggerResponse(401, "Naaah")]
        public IEnumerable<WeatherForecast> GetById(
    [FromQuery, SwaggerParameter("Search id", Required = true)] string id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostAuthWeatherForecast")]
        [SwaggerOperation(
            Summary = "Get the current weather forecast",
            Description = "Requires admin privileges",
            OperationId = "PostAuthWeatherForecast",
            Tags = new[] { "FirstTag", "SecondTag" }
        )]
        [SwaggerResponse(200, "Perfection")]
        [SwaggerResponse(400, "Naaah")]
        public IEnumerable<WeatherForecast> PostAuthWeatherForecast(
    [FromBody, SwaggerRequestBody("Code Academy fun", Required = true)] WeatherForecast weatherForecast)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
