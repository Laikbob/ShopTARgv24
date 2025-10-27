using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShopTARgv24.Core.Dto;

namespace ShopTARgv24.ApplicationServices.Services
{
    public class CocktailService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

        public CocktailService()
        {
            _httpClient = new HttpClient();
        }

        private async Task<T> GetApiResponse<T>(string url)
        {
            var json = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<DrinkDto>> SearchCocktailsByName(string name)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}search.php?s={name}"))?.Drinks;

        public async Task<List<DrinkDto>> SearchCocktailsByFirstLetter(char letter)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}search.php?f={letter}"))?.Drinks;

        public async Task<List<DrinkDto>> SearchCocktailsByIngredient(string ingredient)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}filter.php?i={ingredient}"))?.Drinks;

        public async Task<DrinkDto> GetCocktailById(int id)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}lookup.php?i={id}"))?.Drinks?.FirstOrDefault();

        public async Task<DrinkDto> GetRandomCocktail()
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}random.php"))?.Drinks?.FirstOrDefault();

        public async Task<List<IngredientDto>> ListIngredients()
            => (await GetApiResponse<IngredientApiResponse>($"{BaseUrl}list.php?i=list"))?.Ingredients;

        public async Task<List<DrinkDto>> FilterByAlcoholic(string type) // Alcoholic / Non_Alcoholic
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}filter.php?a={type}"))?.Drinks;

        public async Task<List<DrinkDto>> FilterByCategory(string category)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}filter.php?c={category}"))?.Drinks;

        public async Task<List<DrinkDto>> FilterByGlass(string glass)
            => (await GetApiResponse<CocktailApiResponse>($"{BaseUrl}filter.php?g={glass}"))?.Drinks;
    }
}