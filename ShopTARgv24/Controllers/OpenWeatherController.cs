using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using ShopTARgv24.Models;
using Newtonsoft.Json;

namespace ShopTARgv24.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly OpenWeatherService _service = new OpenWeatherService();

        // GET: /OpenWeather/Index?city=...
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                city = "Tallinn"; // значение по умолчанию
            }

            var data = await _service.GetWeatherAsync(city);
            var weather = JsonConvert.DeserializeObject<WeatherModel>(data);

            ViewBag.City = city; // передаем город в View для формы
            return View(weather);
        }
    }
}
