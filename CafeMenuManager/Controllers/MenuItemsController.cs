using CafeMenuManager.BLL;
using CafeMenuManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenuManager.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly MenuItemService _menuItemService;

        public MenuItemsController(MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: MenuItems
        public IActionResult Index()
        {
            var menuItems = _menuItemService.GetAll();
            return View(menuItems);
        }

        // GET: MenuItems/Details/5
        public IActionResult Details(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemService.Add(menuItem);
                return RedirectToAction(nameof(Index));
            }

            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public IActionResult Edit(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemService.Update(menuItem);
                return RedirectToAction(nameof(Index));
            }

            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public IActionResult Delete(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
