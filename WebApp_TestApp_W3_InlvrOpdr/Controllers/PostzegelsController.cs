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
    public class PostzegelsController : Controller
    {
        private readonly AppDBContext _context;

        public PostzegelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Postzegels
        public IActionResult Index([FromQuery] bool? favoriet = null)
        {
            // Zoek de Gebruiker-entiteit op basis van de gebruikersnaam
            var gebruiker = _context.Gebruikers.FirstOrDefault(u => u.Gebruikersnaam == User.Identity.Name);

            if (gebruiker == null)
            {
                // Gebruiker niet gevonden, return lege lijst
                return View(new List<Postzegel>());
            }

            // Haal de postzegels op voor de huidige gebruiker
            var postzegels = _context.Postzegels
                .Where(p =>
                    p.EigenaarId == gebruiker.Id &&
                    (favoriet == null || p.IsFavoriet == favoriet)
                 ).ToList();

            return View(postzegels);
        }


        // GET: Postzegels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postzegels == null)
            {
                return NotFound();
            }

            var postzegel = await _context.Postzegels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postzegel == null)
            {
                return NotFound();
            }

            return View(postzegel);
        }

        // GET: Postzegels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postzegels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LandVanHerkomst,Conditie,Uitgiftejaar,Waarde,IsFavoriet")] Postzegel postzegel)
        {
            var eigenaar = _context.Gebruikers.FirstOrDefault(u => u.Gebruikersnaam == User.Identity.Name);
            postzegel.Eigenaar = eigenaar;

            ModelState.Clear();
            TryValidateModel(postzegel);

            if (ModelState.IsValid)
            {
                _context.Add(postzegel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postzegel);
        }



        // GET: Postzegels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postzegels == null)
            {
                return NotFound();
            }

            var postzegel = await _context.Postzegels.FindAsync(id);
            if (postzegel == null)
            {
                return NotFound();
            }
            return View(postzegel);
        }

        // POST: Postzegels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Postzegels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LandVanHerkomst,Conditie,Uitgiftejaar,Waarde,IsFavoriet")] Postzegel postzegel)
        {
            if (id != postzegel.Id)
            {
                return NotFound();
            }

            var eigenaar = _context.Gebruikers.FirstOrDefault(u => u.Gebruikersnaam == User.Identity.Name);
            postzegel.Eigenaar = eigenaar;

            ModelState.Clear();
            TryValidateModel(postzegel);

            if (ModelState.IsValid)
            {
                try
                {
                    // Haal de bestaande postzegel op uit de database
                    var existingPostzegel = await _context.Postzegels.FindAsync(id);
                    if (existingPostzegel == null)
                    {
                        return NotFound();
                    }

                    // Update de waardes
                    existingPostzegel.LandVanHerkomst = postzegel.LandVanHerkomst;
                    existingPostzegel.Conditie = postzegel.Conditie;
                    existingPostzegel.Uitgiftejaar = postzegel.Uitgiftejaar;
                    existingPostzegel.Waarde = postzegel.Waarde;
                    existingPostzegel.IsFavoriet = postzegel.IsFavoriet;

                    _context.Update(existingPostzegel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostzegelExists(postzegel.Id))
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
            return View(postzegel);
        }



        // GET: Postzegels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postzegels == null)
            {
                return NotFound();
            }

            var postzegel = await _context.Postzegels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postzegel == null)
            {
                return NotFound();
            }

            return View(postzegel);
        }

        // POST: Postzegels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postzegels == null)
            {
                return Problem("Entity set 'AppDBContext.Postzegels'  is null.");
            }
            var postzegel = await _context.Postzegels.FindAsync(id);
            if (postzegel != null)
            {
                _context.Postzegels.Remove(postzegel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostzegelExists(int id)
        {
            return (_context.Postzegels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

