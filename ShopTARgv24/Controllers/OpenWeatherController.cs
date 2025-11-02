using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using ShopTARgv24.Models;
using Newtonsoft.Json;

namespace ShopTARgv24.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly OpenWeatherService _service = new OpenWeatherService();

        public async Task<IActionResult> Index(string city = "Tallinn")
        {
            var data = await _service.GetWeatherAsync(city);
            var weather = JsonConvert.DeserializeObject<WeatherModel>(data);
            return View(weather);
        }
    }
}
