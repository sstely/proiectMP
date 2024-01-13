using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Allergens
{
    public class DetailsModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public DetailsModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

      public Allergen Allergen { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Allergen == null)
            {
                return NotFound();
            }

            var allergen = await _context.Allergen.FirstOrDefaultAsync(m => m.ID == id);
            if (allergen == null)
            {
                return NotFound();
            }
            else 
            {
                Allergen = allergen;
            }
            return Page();
        }
    }
}
