using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Tasks = new[]
        {
        "Pamiegoti", "Pasapnuoti", "Programuoti", "Pazaisti kompiuterinius zaidimus", "Padeti tevams", "Padaryti labaratorinius darbus", "Pasiruosti egzaminui", "Papramogauti", "Susitikti su draugais", "Padaryti 11 uzduoti"
    };
        private static readonly string[] Status = new[]
     {
        "Ivygdyta","Neivygdyta"
    };
        private static readonly string[] Date = new[]
     {
        "Pirmadienis","Antradienis","Treciadienis","Ketvirtadienis","Penktadienis","Sestadienis","Sekmadienis"
    };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = Date[rng.Next(Date.Length)],
                Status = Status[rng.Next(Status.Length)],
                Summary = Tasks[rng.Next(Tasks.Length)],
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