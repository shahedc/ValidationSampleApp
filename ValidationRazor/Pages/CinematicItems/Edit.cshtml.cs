using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValidationRazor.Models;

namespace ValidationRazor.Pages.CinematicItems
{
    public class EditModel : PageModel
    {
        private readonly ValidationRazor.Models.ValidationRazorContext _context;

        public EditModel(ValidationRazor.Models.ValidationRazorContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CinematicItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinematicItemExists(CinematicItem.Id))
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

        private bool CinematicItemExists(int id)
        {
            return _context.CinematicItem.Any(e => e.Id == id);
        }
    }
}
