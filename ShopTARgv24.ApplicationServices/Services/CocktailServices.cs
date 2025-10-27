using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopTARgv24.ApplicationServices.Services
{
    class CocktailServices
    {
        private readonly HttpClient _httpClient;
        public CocktailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Drink>> GetCocktailsAsync(string apiUrl)
        {
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var root = JsonSerializer.Deserialize<Root>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return root?.Drinks ?? new List<Drink>();
        }
    }
    public class Root
    {
        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }

    public class Drink
    {
        public string? IdDrink { get; set; }
        public string? StrDrink { get; set; }
        public string? StrCategory { get; set; }
        public string? StrAlcoholic { get; set; }
        public string? StrGlass { get; set; }
        public string? StrInstructions { get; set; }
        public string? StrInstructionsZH_HANS { get; set; }
        public string? StrInstructionsZH_HANT { get; set; }
        public string? StrDrinkThumb { get; set; }
        public string? StrIngredient1 { get; set; }
        public string? StrIngredient2 { get; set; }
        public string? StrIngredient3 { get; set; }
        public string? StrIngredient4 { get; set; }
        public string? StrIngredient5 { get; set; }
        public string? StrIngredient6 { get; set; }
        public string? StrIngredient7 { get; set; }
        public string? StrIngredient8 { get; set; }
        public string? StrIngredient9 { get; set; }
        public string? StrIngredient10 { get; set; }
        public string? StrIngredient11 { get; set; }
        public string? StrIngredient12 { get; set; }
        public string? StrIngredient13 { get; set; }
        public string? StrIngredient14 { get; set; }
        public string? StrIngredient15 { get; set; }
        public string? StrMeasure1 { get; set; }
        public string? StrMeasure2 { get; set; }
        public string? StrMeasure3 { get; set; }
        public string? StrMeasure4 { get; set; }
        public string? StrMeasure5 { get; set; }
        public string? StrMeasure6 { get; set; }
        public string? StrMeasure7 { get; set; }
        public string? StrMeasure8 { get; set; }
        public string? StrMeasure9 { get; set; }
        public string? StrMeasure10 { get; set; }
        public string? StrMeasure11 { get; set; }
        public string? StrMeasure12 { get; set; }
        public string? StrMeasure13 { get; set; }
        public string? StrMeasure14 { get; set; }
        public string? StrMeasure15 { get; set; }
    }
}
