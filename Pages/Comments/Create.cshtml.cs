using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiectMP.Data;
using proiectMP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace proiectMP.Pages.Comments
{
    public class CreateModel : PageModel
    {
        private readonly proiectMP.Data.proiectMPContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(proiectMP.Data.proiectMPContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Comment == null || Comment == null)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Email == user.Email);

            Comment.ClientID = client.ID;
            Comment.PostDate = DateTime.Now;

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
