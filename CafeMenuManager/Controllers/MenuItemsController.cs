using CafeMenuManager.BLL;
using CafeMenuManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeMenuManager.Controllers
{
    [Authorize]
    public class MenuItemsController : Controller
    {
        private readonly MenuItemService _menuItemService;
        private readonly CategoryService _categoryService;
        private readonly IngredientService _ingredientService;

        public MenuItemsController(
            MenuItemService menuItemService,
            CategoryService categoryService,
            IngredientService ingredientService)
        {
            _menuItemService = menuItemService;
            _categoryService = categoryService;
            _ingredientService = ingredientService;
        }

        public IActionResult Index()
        {
            var menuItems = _menuItemService.GetAll();
            return View(menuItems);
        }

        public IActionResult Details(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        public IActionResult Create()
        {
            LoadCategories();
            LoadIngredients();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem menuItem, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                if (selectedIngredients != null)
                {
                    menuItem.Ingredients = _ingredientService
                        .GetAll()
                        .Where(i => selectedIngredients.Contains(i.IngredientId))
                        .ToList();
                }

                _menuItemService.Add(menuItem);

                return RedirectToAction(nameof(Index));
            }

            LoadCategories();
            LoadIngredients();

            return View(menuItem);
        }

        public IActionResult Edit(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            LoadCategories();
            LoadIngredients();

            return View(menuItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MenuItem menuItem, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                if (selectedIngredients != null)
                {
                    menuItem.Ingredients = _ingredientService
                        .GetAll()
                        .Where(i => selectedIngredients.Contains(i.IngredientId))
                        .ToList();
                }

                _menuItemService.Update(menuItem);

                return RedirectToAction(nameof(Index));
            }

            LoadCategories();
            LoadIngredients();

            return View(menuItem);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var menuItem = _menuItemService.GetById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuItemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(
                _categoryService.GetAll(),
                "CategoryId",
                "Name");
        }

        private void LoadIngredients()
        {
            ViewBag.Ingredients = _ingredientService.GetAll();
        }
    }
}