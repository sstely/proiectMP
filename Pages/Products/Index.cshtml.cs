using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public IndexModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int IngredientID { get; set; }
        public int AllergenID { get; set; }


        public async Task OnGetAsync(int? id, int? ingredientID, int? allergenID)
        {
            ProductD = new ProductData();

            ProductD.Products = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductIngredients).ThenInclude(p => p.Ingredient)
                .Include(p => p.ProductAllergens).ThenInclude(p => p.Allergen)
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToListAsync();

            if (id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products.Where(i => i.ID == id.Value).Single();
                ProductD.Ingredients = product.ProductIngredients.Select(s => s.Ingredient);
                ProductD.Allergens = product.ProductAllergens.Select(s => s.Allergen);
            }
        }
    }
}
