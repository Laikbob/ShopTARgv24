using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.Models;
using System.Linq;

namespace ShopTARgv24.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARgv24Context _context;

        public SpaceshipsController(ShopTARgv24Context context) => _context = context;

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Buildate = x.BultiDate,
                    TypeName = x.Typename
                });

            return View(result);
        }
    }
}

