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
    public class DetailsModel : PageModel
    {
        private readonly ValidationRazor.Models.ValidationRazorContext _context;

        public DetailsModel(ValidationRazor.Models.ValidationRazorContext context)
        {
            _context = context;
        }

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
    }
}
