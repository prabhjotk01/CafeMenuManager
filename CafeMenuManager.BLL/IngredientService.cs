using CafeMenuManager.DAL;
using CafeMenuManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuManager.BLL
{
    public class IngredientService
    {
        private readonly CafeMenuContext _context;

        public IngredientService(CafeMenuContext context)
        {
            _context = context;
        }

        public List<Ingredient> GetAll()
        {
            return _context.Ingredients
                .Include(i => i.MenuItems)
                .ToList();
        }

        public Ingredient GetById(int id)
        {
            return _context.Ingredients
                .Include(i => i.MenuItems)
                .FirstOrDefault(i => i.IngredientId == id);
        }

        public void Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Ingredient ingredient = _context.Ingredients.Find(id);

            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }
    }
}
