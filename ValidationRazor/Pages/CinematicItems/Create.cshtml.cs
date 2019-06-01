using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValidationRazor.Models;

namespace ValidationRazor.Pages.CinematicItems
{
    public class CreateModel : PageModel
    {
        private readonly ValidationRazor.Models.ValidationRazorContext _context;

        public CreateModel(ValidationRazor.Models.ValidationRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CinematicItem CinematicItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CinematicItem.Add(CinematicItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}