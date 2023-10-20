using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_TestApp_W3_InlvrOpdr.Models;

namespace WebApp_TestApp_W3_InlvrOpdr.Controllers
{
    public class BerichtsController : Controller
    {
        private readonly AppDBContext _context;

        public BerichtsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Berichts
        public async Task<IActionResult> Index()
        {
              return _context.Bericht != null ? 
                          View(await _context.Bericht.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Bericht'  is null.");
        }

        // GET: Berichts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bericht == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bericht == null)
            {
                return NotFound();
            }

            return View(bericht);
        }

        // GET: Berichts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Berichts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Inhoud,Datum")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bericht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bericht);
        }

        // GET: Berichts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bericht == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht.FindAsync(id);
            if (bericht == null)
            {
                return NotFound();
            }
            return View(bericht);
        }

        // POST: Berichts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Inhoud,Datum")] Bericht bericht)
        {
            if (id != bericht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bericht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BerichtExists(bericht.Id))
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
            return View(bericht);
        }

        // GET: Berichts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bericht == null)
            {
                return NotFound();
            }

            var bericht = await _context.Bericht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bericht == null)
            {
                return NotFound();
            }

            return View(bericht);
        }

        // POST: Berichts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bericht == null)
            {
                return Problem("Entity set 'AppDBContext.Bericht'  is null.");
            }
            var bericht = await _context.Bericht.FindAsync(id);
            if (bericht != null)
            {
                _context.Bericht.Remove(bericht);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BerichtExists(int id)
        {
          return (_context.Bericht?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
