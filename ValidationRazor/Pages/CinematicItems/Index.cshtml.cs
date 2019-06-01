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
    public class IndexModel : PageModel
    {
        private readonly ValidationRazor.Models.ValidationRazorContext _context;

        public IndexModel(ValidationRazor.Models.ValidationRazorContext context)
        {
            _context = context;
        }

        public IList<CinematicItem> CinematicItem { get;set; }

        public async Task OnGetAsync()
        {
            CinematicItem = await _context.CinematicItem.ToListAsync();
        }
    }
}
