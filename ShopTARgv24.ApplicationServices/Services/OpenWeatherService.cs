using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv24.ApplicationServices.Services
{
    public class OpenWeatherService
    {
        //d28f530e339b8fada4ad816ddd365ff6
        private readonly string apiKey = "d28f530e339b8fada4ad816ddd365ff6";
        private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<string> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}?q={city}&appid={apiKey}&units=metric";
                var response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
