using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using System.Threading.Tasks;

namespace ShopTARgv24.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CocktailsController : ControllerBase
    {
        private readonly CocktailService _cocktailService;

        public CocktailsController()
        {
            _cocktailService = new CocktailService();
        }

        // GET api/cocktails/search?name=Margarita
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var drinks = await _cocktailService.SearchCocktailsByName(name);
            if (drinks == null || drinks.Count == 0)
                return NotFound("Cocktail not found");
            return Ok(drinks);
        }

        // GET api/cocktails/letter?a
        [HttpGet("letter")]
        public async Task<IActionResult> SearchByFirstLetter([FromQuery] char letter)
        {
            var drinks = await _cocktailService.SearchCocktailsByFirstLetter(letter);
            return Ok(drinks);
        }

        // GET api/cocktails/ingredient?name=Vodka
        [HttpGet("ingredient")]
        public async Task<IActionResult> SearchByIngredient([FromQuery] string name)
        {
            var drinks = await _cocktailService.SearchCocktailsByIngredient(name);
            return Ok(drinks);
        }

        // GET api/cocktails/id/11007
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var drink = await _cocktailService.GetCocktailById(id);
            if (drink == null)
                return NotFound("Cocktail not found");
            return Ok(drink);
        }

        // GET api/cocktails/random
        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            var drink = await _cocktailService.GetRandomCocktail();
            return Ok(drink);
        }

        // GET api/cocktails/ingredients
        [HttpGet("ingredients")]
        public async Task<IActionResult> ListIngredients()
        {
            var ingredients = await _cocktailService.ListIngredients();
            return Ok(ingredients);
        }

        // GET api/cocktails/filter/alcoholic?type=Alcoholic
        [HttpGet("filter/alcoholic")]
        public async Task<IActionResult> FilterByAlcoholic([FromQuery] string type)
        {
            var drinks = await _cocktailService.FilterByAlcoholic(type);
            return Ok(drinks);
        }

        // GET api/cocktails/filter/category?category=Cocktail
        [HttpGet("filter/category")]
        public async Task<IActionResult> FilterByCategory([FromQuery] string category)
        {
            var drinks = await _cocktailService.FilterByCategory(category);
            return Ok(drinks);
        }

        // GET api/cocktails/filter/glass?glass=Cocktail_glass
        [HttpGet("filter/glass")]
        public async Task<IActionResult> FilterByGlass([FromQuery] string glass)
        {
            var drinks = await _cocktailService.FilterByGlass(glass);
            return Ok(drinks);
        }
    }
}
