using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Migrations;
using proiectMP.Models;

namespace proiectMP.Pages.ProductsByCategory
{
    public class DetailsModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public DetailsModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;
        public int IngredientID { get; set; }
        public int AllergenID { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync(int categoryId, int? id, int? ingredientID, int? allergenID)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var category = _context.Category.FirstOrDefault(c => c.ID == categoryId);
            CategoryID = categoryId;
            CategoryName = category.CategoryName;

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductIngredients).ThenInclude(p => p.Ingredient)
                .Include(p => p.ProductAllergens).ThenInclude(p => p.Allergen)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
