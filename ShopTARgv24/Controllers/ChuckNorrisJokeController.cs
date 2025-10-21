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

        // Action для отображения страницы с кнопкой
        public IActionResult Index()
        {
            return View();  // Теперь эта строка найдет представление /Views/ChuckNorrisJoke/Index.cshtml
        }

        // Action для получения случайной шутки
        [HttpGet]
        public async Task<IActionResult> GetRandomJoke()
        {
            var joke = await _jokeService.GetRandomJokeAsync();
            return Json(new { joke });  // Отправляем шутку в формате JSON
        }
    }
}