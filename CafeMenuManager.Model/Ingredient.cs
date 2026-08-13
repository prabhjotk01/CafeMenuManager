using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CafeMenuManager.Model
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
