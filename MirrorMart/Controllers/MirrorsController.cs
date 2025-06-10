using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        // Allow Everyone
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mirrors.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var mirror = await _context.Mirrors.FirstOrDefaultAsync(m => m.Id == id);
            if (mirror == null) return NotFound();

            return View(mirror);
        }

        // Only Admin can access these:
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var mirror = await _context.Mirrors.FindAsync(id);
            if (mirror == null) return NotFound();

            return View(mirror);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Price,Material,Size,Shape")] Mirror mirror)
        {
            if (id != mirror.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mirror);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MirrorExists(mirror.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mirror);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mirror = await _context.Mirrors.FirstOrDefaultAsync(m => m.Id == id);
            if (mirror == null) return NotFound();

            return View(mirror);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mirror = await _context.Mirrors.FindAsync(id);
            if (mirror != null)
            {
                _context.Mirrors.Remove(mirror);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MirrorExists(int id)
        {
            return _context.Mirrors.Any(e => e.Id == id);
        }
    }
}
