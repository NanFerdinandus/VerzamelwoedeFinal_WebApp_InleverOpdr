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
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _context;

        public CategoriesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Categorieën.Include(c => c.Postzegel);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categorieën == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorieën
                .Include(c => c.Postzegel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["PostzegelId"] = new SelectList(_context.Postzegels, "Id", "Id");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategorieNaam,Beschrijving,PostzegelId")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostzegelId"] = new SelectList(_context.Postzegels, "Id", "Id", categorie.PostzegelId);
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categorieën == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorieën.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            ViewData["PostzegelId"] = new SelectList(_context.Postzegels, "Id", "Id", categorie.PostzegelId);
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategorieNaam,Beschrijving,PostzegelId")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.Id))
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
            ViewData["PostzegelId"] = new SelectList(_context.Postzegels, "Id", "Id", categorie.PostzegelId);
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categorieën == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorieën
                .Include(c => c.Postzegel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categorieën == null)
            {
                return Problem("Entity set 'AppDBContext.Categorieën'  is null.");
            }
            var categorie = await _context.Categorieën.FindAsync(id);
            if (categorie != null)
            {
                _context.Categorieën.Remove(categorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
          return (_context.Categorieën?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
