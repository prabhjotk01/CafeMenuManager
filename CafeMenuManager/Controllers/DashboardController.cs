using Microsoft.AspNetCore.Mvc;
using CafeMenuManager.DAL;
using Microsoft.AspNetCore.Authorization;

namespace CafeMenuManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly CafeMenuContext _context;

        public DashboardController(CafeMenuContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.MenuItemCount = _context.MenuItems.Count();
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.IngredientCount = _context.Ingredients.Count();

            return View();
        }
    }
}
