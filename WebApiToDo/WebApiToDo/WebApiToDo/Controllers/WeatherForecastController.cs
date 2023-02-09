using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Šalta", "Vėjuotas", "Vėsu", "Labai šalta", "Vidutiniškai", "Šilta", "Audringas oras", "Karšta", "Prakaituojantis oras", "Deginantis"
    };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();

            // Write the data to a JSON file
            using (var writer = new StreamWriter("weatherForecasts.json"))
            {
                var json = JsonSerializer.Serialize(weatherForecasts);
                writer.Write(json);
            }

            return weatherForecasts;
        }
    }
}