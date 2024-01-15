using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Allergens
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public IndexModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        public IList<Allergen> Allergen { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Allergen != null)
            {
                Allergen = await _context.Allergen.ToListAsync();
            }
        }
    }
}
