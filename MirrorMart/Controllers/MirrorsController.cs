using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MirrorMart.Data;
using MirrorMart.Models;

namespace MirrorMart.Controllers
{
    public class MirrorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MirrorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mirrors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mirrors.ToListAsync());
        }

        // GET: Mirrors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.Mirrors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mirror == null)
            {
                return NotFound();
            }

            return View(mirror);
        }

        // GET: Mirrors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mirrors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Price,Material,Size,Shape")] Mirror mirror)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mirror);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mirror);
        }

        // GET: Mirrors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.Mirrors.FindAsync(id);
            if (mirror == null)
            {
                return NotFound();
            }
            return View(mirror);
        }

        // POST: Mirrors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Price,Material,Size,Shape")] Mirror mirror)
        {
            if (id != mirror.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mirror);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MirrorExists(mirror.Id))
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
            return View(mirror);
        }

        // GET: Mirrors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mirror = await _context.Mirrors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mirror == null)
            {
                return NotFound();
            }

            return View(mirror);
        }

        // POST: Mirrors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mirror = await _context.Mirrors.FindAsync(id);
            if (mirror != null)
            {
                _context.Mirrors.Remove(mirror);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MirrorExists(int id)
        {
            return _context.Mirrors.Any(e => e.Id == id);
        }
    }
}
