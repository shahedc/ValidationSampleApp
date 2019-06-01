using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ValidationRazor.Models
{
    public class ValidationRazorContext : DbContext
    {
        public ValidationRazorContext (DbContextOptions<ValidationRazorContext> options)
            : base(options)
        {
        }

        public DbSet<ValidationRazor.Models.CinematicItem> CinematicItem { get; set; }
    }
}
