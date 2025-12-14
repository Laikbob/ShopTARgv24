using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using System.Threading.Tasks;


namespace ShopTARgv24.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly ChuckNorrisService _Service;

        public ChuckNorrisController(ChuckNorrisService jokeService)
        {
            _Service = jokeService;
        }

        public IActionResult Index()
        {
            return View();  
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomJoke()
        {
            var joke = await _Service.GetRandomJokeAsync();
            return Json(new { joke });  
        }
    }
}