using CafeMenuManager.BLL;
using CafeMenuManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenuManager.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IngredientService _ingredientService;

        public IngredientsController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult Index()
        {
            var ingredients = _ingredientService.GetAll();
            return View(ingredients);
        }

        public IActionResult Details(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _ingredientService.Add(ingredient);
                return RedirectToAction(nameof(Index));
            }

            return View(ingredient);
        }

        public IActionResult Edit(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _ingredientService.Update(ingredient);
                return RedirectToAction(nameof(Index));
            }

            return View(ingredient);
        }

        public IActionResult Delete(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ingredientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
