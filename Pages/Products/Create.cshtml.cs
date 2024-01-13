using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Products
{
    public class CreateModel : ProductIngrAllrgPageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public CreateModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var product = new Product();

            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");

            product.ProductIngredients = new List<ProductIngredient>();
            product.ProductAllergens = new List<ProductAllergen>();

            PopulateAssignedIngredientData(_context, product);  
            PopulateAssignedAllergenData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedIngredients, string[] selectedAllergens)
        {
            var newProduct = new Product();

            if (selectedIngredients != null)
            {
                newProduct.ProductIngredients = new List<ProductIngredient>();

                foreach (var ingr in selectedIngredients)
                {
                    var ingrToAdd = new ProductIngredient
                    {
                        IngredientID = int.Parse(ingr)
                    };
                    newProduct.ProductIngredients.Add(ingrToAdd);
                }
            }

            if (selectedAllergens != null)
            {
                newProduct.ProductAllergens = new List<ProductAllergen>();

                foreach (var alg in selectedAllergens)
                {
                    var algToAdd = new ProductAllergen
                    {
                        AllergenID = int.Parse(alg)
                    };
                    newProduct.ProductAllergens.Add(algToAdd);
                }
            }

            Product.ProductIngredients = newProduct.ProductIngredients;
            Product.ProductAllergens = newProduct.ProductAllergens;

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
