using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using ShopTARgv24.Data;

namespace ShopTARgv24.Controllers
{
    public class ShopTARgv24Context : DbContext
    {
        public object Spaceships { get; private set; }

        public class SpaceshipsController : Controller
        {
            private readonly ShopTARgv24Context _context;

            public SpaceshipsController
                (
                    ShopTARgv24Context context
                )
            {
                _context = context;
            }
            public IActionResult Index()
            {
                var result = _context.Spaceships
                    .Select(x => new SpaceshipsControllerModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Buildate = x.Buildate,
                        TypeName = x.TypeName

                    });
                return View();
            }
        }
    }
}
