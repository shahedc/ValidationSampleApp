using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValidationMvc.Models;
using ValidationMvc.Data;

namespace ValidationMvc.Controllers
{
    public class CinematicItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinematicItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CinematicItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.CinematicItem.ToListAsync());
        }

        // GET: CinematicItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinematicItem == null)
            {
                return NotFound();
            }

            return View(cinematicItem);
        }

        // GET: CinematicItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinematicItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Synopsis,AvailableDate,CIType")] CinematicItem cinematicItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinematicItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinematicItem);
        }

        // GET: CinematicItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItem.FindAsync(id);
            if (cinematicItem == null)
            {
                return NotFound();
            }
            return View(cinematicItem);
        }

        // POST: CinematicItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Synopsis,AvailableDate,CIType")] CinematicItem cinematicItem)
        {
            if (id != cinematicItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinematicItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinematicItemExists(cinematicItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cinematicItem);
        }

        // GET: CinematicItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinematicItem == null)
            {
                return NotFound();
            }

            return View(cinematicItem);
        }

        // POST: CinematicItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinematicItem = await _context.CinematicItem.FindAsync(id);
            _context.CinematicItem.Remove(cinematicItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinematicItemExists(int id)
        {
            return _context.CinematicItem.Any(e => e.Id == id);
        }
    }
}
