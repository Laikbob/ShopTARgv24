using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.ApplicationServices.Services;
using System.Threading.Tasks;


namespace ShopTARgv24.Controllers
{
    public class ChuckNorrisJokeController : Controller
    {
        private readonly ChuckNorrisJokeService _jokeService;

        public ChuckNorrisJokeController(ChuckNorrisJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public IActionResult Index()
        {
            return View();  
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomJoke()
        {
            var joke = await _jokeService.GetRandomJokeAsync();
            return Json(new { joke });  
        }
    }
}