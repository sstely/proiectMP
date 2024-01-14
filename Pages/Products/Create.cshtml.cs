using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ProductIngrAllrgPageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(proiectMP.Data.proiectMPContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

            /*
            byte[] bytes = null;

            if(Product.CoverImageFile != null)
            {
                using(Stream fs = Product.CoverImageFile.OpenReadStream())
                {
                    using(BinaryReader br =  new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }

                Product.CoverImageURL = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            */

            if(Product.CoverImageFile != null)
            {
                string folder = "products/cover/";
                folder += Guid.NewGuid().ToString() + "_" + Product.CoverImageFile.FileName;

                Product.CoverImageURL = "/" + folder;

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await Product.CoverImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
