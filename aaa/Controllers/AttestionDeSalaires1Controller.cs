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
    public class AttestionDeSalaires1Controller : Controller
    {
        private readonly AppDbContext _context;

        public AttestionDeSalaires1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: AttestionDeSalaires1
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AttestionDeSalaires.Include(a => a.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AttestionDeSalaires1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeSalaire = await _context.AttestionDeSalaires
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AttestionDeSalaireId == id);
            if (attestionDeSalaire == null)
            {
                return NotFound();
            }

            return View(attestionDeSalaire);
        }

        // GET: AttestionDeSalaires1/Create
        public IActionResult Create()
        {
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName");
            return View();
        }

        // POST: AttestionDeSalaires1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttestionDeSalaireId,DossierId,AttestionDeSalaireAnnee,PériondesD,PériondesA,DuréeDuTravail,SalaireSoumisRetenue,DésignationDeLemploi,DesiguationDeLaClasseDallocation")] AttestionDeSalaire attestionDeSalaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attestionDeSalaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeSalaire.DossierId);
            return View(attestionDeSalaire);
        }

        // GET: AttestionDeSalaires1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeSalaire = await _context.AttestionDeSalaires.FindAsync(id);
            if (attestionDeSalaire == null)
            {
                return NotFound();
            }
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeSalaire.DossierId);
            return View(attestionDeSalaire);
        }

        // POST: AttestionDeSalaires1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttestionDeSalaireId,DossierId,AttestionDeSalaireAnnee,PériondesD,PériondesA,DuréeDuTravail,SalaireSoumisRetenue,DésignationDeLemploi,DesiguationDeLaClasseDallocation")] AttestionDeSalaire attestionDeSalaire)
        {
            if (id != attestionDeSalaire.AttestionDeSalaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attestionDeSalaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttestionDeSalaireExists(attestionDeSalaire.AttestionDeSalaireId))
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
            ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "EmployeeName", attestionDeSalaire.DossierId);
            return View(attestionDeSalaire);
        }

        // GET: AttestionDeSalaires1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attestionDeSalaire = await _context.AttestionDeSalaires
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AttestionDeSalaireId == id);
            if (attestionDeSalaire == null)
            {
                return NotFound();
            }

            return View(attestionDeSalaire);
        }

        // POST: AttestionDeSalaires1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attestionDeSalaire = await _context.AttestionDeSalaires.FindAsync(id);
            _context.AttestionDeSalaires.Remove(attestionDeSalaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttestionDeSalaireExists(int id)
        {
            return _context.AttestionDeSalaires.Any(e => e.AttestionDeSalaireId == id);
        }
    }
}
