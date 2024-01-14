using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiectMP.Data;
using proiectMP.Models;

namespace proiectMP.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;

        public IndexModel(proiectMP.Data.proiectMPContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Comment != null)
            {
                Comment = await _context.Comment
                .Include(c => c.Client).ToListAsync();
            }
        }
    }
}
