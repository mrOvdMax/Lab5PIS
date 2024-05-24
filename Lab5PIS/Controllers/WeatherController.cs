using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Lab5PIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey;

        public WeatherController()
        {
            apiKey = "3e4be5b149d248345ad9c8e5d8d60d63";
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("API key for OpenWeatherMap is not configured.");
            }
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json);

                    double temperatureKelvin = data["main"]["temp"].Value<double>();
                    double temperatureCelsius = temperatureKelvin - 273.15;
                    string description = data["weather"][0]["description"].Value<string>();

                    var result = new
                    {
                        City = cityName,
                        Temperature = temperatureCelsius,
                        Description = description
                    };

                    return Ok(result);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return StatusCode(401, "Unauthorized: Invalid API key.");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Error fetching data from OpenWeatherMap API.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
