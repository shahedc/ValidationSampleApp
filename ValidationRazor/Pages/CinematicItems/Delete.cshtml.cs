using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValidationRazor.Models;

namespace ValidationRazor.Pages.CinematicItems
{
    public class DeleteModel : PageModel
    {
        private readonly ValidationRazor.Models.ValidationRazorContext _context;

        public DeleteModel(ValidationRazor.Models.ValidationRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CinematicItem CinematicItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinematicItem = await _context.CinematicItem.FirstOrDefaultAsync(m => m.Id == id);

            if (CinematicItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinematicItem = await _context.CinematicItem.FindAsync(id);

            if (CinematicItem != null)
            {
                _context.CinematicItem.Remove(CinematicItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
