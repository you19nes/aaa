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
    public class AttestionTravailsController : Controller
    {
        private readonly AppDbContext _context;

        public AttestionTravailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AttestionTravails
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AttestionTravails.Include(a => a.Dossier);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AttestionTravails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionTravail = await _context.AttestionTravails
                .Include(a => a.Dossier)
                .FirstOrDefaultAsync(m => m.AttestionTravailId == id);
            if (attestionTravail == null)
            {
                return NotFound();
            }

            return View(attestionTravail);
        }

        // GET: AttestionTravails/Create
        public IActionResult Create()
        {
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName");
            return View();
        }

        // POST: AttestionTravails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttestionTravailId,DossierId,PeriodeReference,SalaireSoumisCotisation")] AttestionTravail attestionTravail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attestionTravail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionTravail.DossierId);
            return View(attestionTravail);
        }

        // GET: AttestionTravails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionTravail = await _context.AttestionTravails.FindAsync(id);
            if (attestionTravail == null)
            {
                return NotFound();
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionTravail.DossierId);
            return View(attestionTravail);
        }

        // POST: AttestionTravails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttestionTravailId,DossierId,PeriodeReference,SalaireSoumisCotisation")] AttestionTravail attestionTravail)
        {
            if (id != attestionTravail.AttestionTravailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attestionTravail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttestionTravailExists(attestionTravail.AttestionTravailId))
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
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionTravail.DossierId);
            return View(attestionTravail);
        }

        // GET: AttestionTravails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionTravail = await _context.AttestionTravails
                .Include(a => a.Dossier)
                .FirstOrDefaultAsync(m => m.AttestionTravailId == id);
            if (attestionTravail == null)
            {
                return NotFound();
            }

            return View(attestionTravail);
        }

        // POST: AttestionTravails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attestionTravail = await _context.AttestionTravails.FindAsync(id);
            _context.AttestionTravails.Remove(attestionTravail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttestionTravailExists(int id)
        {
            return _context.AttestionTravails.Any(e => e.AttestionTravailId == id);
        }
    }
}
