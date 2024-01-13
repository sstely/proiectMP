using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public DeleteModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ingredient == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FirstOrDefaultAsync(m => m.ID == id);

            if (ingredient == null)
            {
                return NotFound();
            }
            else 
            {
                Ingredient = ingredient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ingredient == null)
            {
                return NotFound();
            }
            var ingredient = await _context.Ingredient.FindAsync(id);

            if (ingredient != null)
            {
                Ingredient = ingredient;
                _context.Ingredient.Remove(Ingredient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
