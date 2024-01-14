using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Migrations;
using proiectMP.Models;

namespace proiectMP.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ProductIngrAllrgPageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public EditModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductIngredients).ThenInclude(p => p.Ingredient)
                .Include(p => p.ProductAllergens).ThenInclude(p => p.Allergen)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }

            PopulateAssignedIngredientData(_context, Product);
            PopulateAssignedAllergenData(_context, Product);

            ViewData["CategoryID"] = new SelectList(_context.Set<Models.Category>(), "ID", "CategoryName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedIngredients, string[] selectedAllergens)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Product
                .Include(i => i.Category)
                .Include(i => i.ProductIngredients).ThenInclude(i => i.Ingredient)
                .Include(i => i.ProductAllergens).ThenInclude(i => i.Allergen)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                productToUpdate,
                "Product",
                i => i.Name, 
                i => i.Description,
                i => i.CategoryID,
                i => i.Price, 
                i => i.Quantity, 
                i => i.CoverImageURL)
                )
            {
                UpdateProductIngredients(_context, selectedIngredients, productToUpdate);
                UpdateProductAllergens(_context, selectedAllergens, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateProductIngredients(_context, selectedIngredients, productToUpdate);
            UpdateProductAllergens(_context, selectedAllergens, productToUpdate);

            PopulateAssignedIngredientData(_context, productToUpdate);
            PopulateAssignedAllergenData(_context, productToUpdate);

            return Page();
        }
    }
}
