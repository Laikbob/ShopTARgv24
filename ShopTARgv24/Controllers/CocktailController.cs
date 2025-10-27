using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using ShopTARgv24.Models.Cocktail;


namespace ShopTARgv24.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly CocktailService _cocktailService;

        public CocktailsController()
        {
            _cocktailService = new CocktailService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CocktailSearchModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CocktailSearchModel model)
        {
            if (!string.IsNullOrEmpty(model.CocktailName))
            {
                model.Drinks = await _cocktailService.SearchCocktailsByName(model.CocktailName);
            }
            return View(model);
        }
    }
}