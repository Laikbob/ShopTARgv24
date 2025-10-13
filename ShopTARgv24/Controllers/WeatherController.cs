using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using ShopTARgv24.Core.ServiceInterface;

namespace ShopTARgv24.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecsastServices _weatherForecastServices;

        public WeatherController(IWeatherForecsastServices weatherForecastServices)
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Search city 
        [HttpPost]
        public IActionResult Search(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                ModelState.AddModelError("", "Please enter a city name.");
                return View("Index");
            }

            
            var weatherData = _weatherForecastServices.GetWeatherByCity(city);

            if (weatherData == null)
            {
                ModelState.AddModelError("", "Weather data not found for the specified city.");
                return View("Index");
            }

            return View("WeatherResult", weatherData);
        }
    }
}
