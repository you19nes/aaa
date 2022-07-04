using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aaa.Data;
using aaa.Models;

namespace aaa.Controllers
{
    public class AttestionDeCesseisons1Controller : Controller
    {
        private readonly AppDbContext _context;

        public AttestionDeCesseisons1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: AttestionDeCesseisons1
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AttestionDeCesseisons.Include(a => a.Dossier);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AttestionDeCesseisons1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeCesseison = await _context.AttestionDeCesseisons
                .Include(a => a.Dossier)
                .FirstOrDefaultAsync(m => m.AttestionDeCesseisonId == id);
            if (attestionDeCesseison == null)
            {
                return NotFound();
            }

            return View(attestionDeCesseison);
        }

        // GET: AttestionDeCesseisons1/Create
        public IActionResult Create()
        {
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName");
            return View();
        }

        // POST: AttestionDeCesseisons1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttestionDeCesseisonId,DossierId,Nom_ET_Prenom,RaisonSociale,Adresse,NDassurance,Date")] AttestionDeCesseison attestionDeCesseison)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attestionDeCesseison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeCesseison.DossierId);
            return View(attestionDeCesseison);
        }

        // GET: AttestionDeCesseisons1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeCesseison = await _context.AttestionDeCesseisons.FindAsync(id);
            if (attestionDeCesseison == null)
            {
                return NotFound();
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeCesseison.DossierId);
            return View(attestionDeCesseison);
        }

        // POST: AttestionDeCesseisons1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttestionDeCesseisonId,DossierId,Nom_ET_Prenom,RaisonSociale,Adresse,NDassurance,Date")] AttestionDeCesseison attestionDeCesseison)
        {
            if (id != attestionDeCesseison.AttestionDeCesseisonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attestionDeCesseison);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttestionDeCesseisonExists(attestionDeCesseison.AttestionDeCesseisonId))
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
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeCesseison.DossierId);
            return View(attestionDeCesseison);
        }

        // GET: AttestionDeCesseisons1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeCesseison = await _context.AttestionDeCesseisons
                .Include(a => a.Dossier)
                .FirstOrDefaultAsync(m => m.AttestionDeCesseisonId == id);
            if (attestionDeCesseison == null)
            {
                return NotFound();
            }

            return View(attestionDeCesseison);
        }

        // POST: AttestionDeCesseisons1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attestionDeCesseison = await _context.AttestionDeCesseisons.FindAsync(id);
            _context.AttestionDeCesseisons.Remove(attestionDeCesseison);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttestionDeCesseisonExists(int id)
        {
            return _context.AttestionDeCesseisons.Any(e => e.AttestionDeCesseisonId == id);
        }
    }
}
