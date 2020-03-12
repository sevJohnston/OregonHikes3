using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OregonHikes3.Models;
using OregonHikes3.Repositories;

namespace OregonHikes3.Controllers
{
    public class HikesController : Controller
    {
        private readonly AppDbContext _context;

        //constructor uses DI to inject the DbContext into the controller
        public HikesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hikes.ToListAsync());
        }

        // GET: Hikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hike = await _context.Hikes
                .FirstOrDefaultAsync(m => m.HikeID == id);
            if (hike == null)
            {
                return NotFound();
            }

            return View(hike);
        }

        // GET: Hikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HikeID,TrailName,Region,Description")] Hike hike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hike);
        }

        // GET: Hikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hike = await _context.Hikes.FindAsync(id);
            if (hike == null)
            {
                return NotFound();
            }
            return View(hike);
        }

        // POST: Hikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HikeID,TrailName,Region,Description")] Hike hike)
        {
            if (id != hike.HikeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HikeExists(hike.HikeID))
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
            return View(hike);
        }

        // GET: Hikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hike = await _context.Hikes
                .FirstOrDefaultAsync(m => m.HikeID == id);
            if (hike == null)
            {
                return NotFound();
            }

            return View(hike);
        }

        // POST: Hikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hike = await _context.Hikes.FindAsync(id);
            _context.Hikes.Remove(hike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HikeExists(int id)
        {
            return _context.Hikes.Any(e => e.HikeID == id);
        }
    }
}
