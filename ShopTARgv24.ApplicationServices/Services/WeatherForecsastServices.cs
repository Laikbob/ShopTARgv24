using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Core.Dto;
using System.Text.Json;

namespace ShopTARgv24.ApplicationServices.Services
{
    public class WeatherForecsastServices: IWeatherForecsastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "your_api";
            string baseUlr = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/";

            using (var httpClient = new HttpClient())
            { 
                httpClient.BaseAddress = new Uri(baseUlr);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync($"{127964}?apikey={accuApiKey}&details=true");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<AccuLocationWeatherResultDto>(jsonResponse);
                    return weatherData;
                }
                else
                {
                    throw new Exception("Error fething weather data from AccuWeather API");
                }

            }
        }
    }
}
