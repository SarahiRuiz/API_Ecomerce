using Microsoft.AspNetCore.Mvc;

namespace API_Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
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
        [HttpGet("param/{num1}/{num2}", Name = "param")]
        public String param(int num1, int num2)
        {
            int result = num1 + num2;
            return "<h1>Test 1</h1>" +
                $"{num1} + {num2} = {result}";
        }
        [HttpGet("paramQuery", Name = "paramQuery")]
        public String paramQuery([FromQuery]int num1, [FromQuery]int num2)
        {
            int result = num1 + num2;
            return "<h1>Test 1</h1>" +
                $"{num1} + {num2} = {result}";
        }
    }
}
