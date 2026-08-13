using CafeMenuManager.DAL;
using CafeMenuManager.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CafeMenuManager.BLL
{
    public class MenuItemService
    {
        private readonly CafeMenuContext _context;

        public MenuItemService(CafeMenuContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAll()
        {
            return _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.Ingredients)
                .ToList();
        }

        public MenuItem GetById(int id)
        {
            return _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.Ingredients)
                .FirstOrDefault(m => m.MenuItemId == id);
        }

        public void Add(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }

        public void Update(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            MenuItem menuItem = _context.MenuItems.Find(id);

            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                _context.SaveChanges();
            }
        }
    }
}