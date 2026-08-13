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
    public  class CategoryService
    {
        private readonly CafeMenuContext _context;

        public CategoryService(CafeMenuContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories
                .Include(c => c.MenuItems)
                .ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories
                .Include(c => c.MenuItems)
                .FirstOrDefault(c => c.CategoryId == id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
