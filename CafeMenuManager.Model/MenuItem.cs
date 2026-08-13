using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CafeMenuManager.Model
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Menu item name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
