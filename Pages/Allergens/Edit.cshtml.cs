using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Allergens
{
    public class EditModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public EditModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Allergen Allergen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Allergen == null)
            {
                return NotFound();
            }

            var allergen =  await _context.Allergen.FirstOrDefaultAsync(m => m.ID == id);
            if (allergen == null)
            {
                return NotFound();
            }
            Allergen = allergen;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Allergen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergenExists(Allergen.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AllergenExists(int id)
        {
          return (_context.Allergen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
