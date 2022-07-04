using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aaa.Data;
using aaa.Models;
using Microsoft.AspNetCore.Authorization;

namespace aaa.Controllers
{
   
    public class Dossiers1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Dossiers1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dossiers1
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var students = _context.dossiers.Select(emp => emp);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.EmployeeName.Contains(searchString)
                                       || s.EmployeePrenom.Contains(searchString));
            }
            return View(students);
        }
        

        // GET: Dossiers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossier = await _context.dossiers
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossier == null)
            {
                return NotFound();
            }

            return View(dossier);
        }

        // GET: Dossiers1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dossiers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DossierId,EmployeeName,EmployeePrenom,DeteNaissance,Adressedenaissence,Address,NaissanceWilaya,Titredecivilite,Lemployeursoussigné,NSSEMPLOYEUR,NASASSURE,Qualite,NumeroAllocationFamilailes,NumeroAllocationAssure,NumeroSocialesFamilailes,NumeroSocialesAssure,DubutTravail,FinTravail,nom,pre,ParronPere,Parronmere,makan,wilaia,mihna,onwan,safha,Etat")] Dossier dossier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dossier);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employe", "Dossiers");
            }
            return View(dossier);
        }
        
        // GET: Dossiers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossier = await _context.dossiers.FindAsync(id);
            if (dossier == null)
            {
                return NotFound();
            }
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
            return View(dossier);
        }

        // POST: Dossiers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DossierId,EmployeeName,EmployeePrenom,DeteNaissance,Adressedenaissence,Address,NaissanceWilaya,Titredecivilite,Lemployeursoussigné,NSSEMPLOYEUR,NASASSURE,Qualite,NumeroAllocationFamilailes,NumeroAllocationAssure,NumeroSocialesFamilailes,NumeroSocialesAssure,DubutTravail,FinTravail,nom,pre,ParronPere,Parronmere,makan,wilaia,mihna,onwan,safha,Etat")] Dossier dossier)
        {
            if (id != dossier.DossierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dossier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossierExists(dossier.DossierId))
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
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
            return View(dossier);
        }

        // GET: Dossiers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossier = await _context.dossiers
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossier == null)
            {
                return NotFound();
            }

            return View(dossier);
        }

        // POST: Dossiers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dossier = await _context.dossiers.FindAsync(id);
            _context.dossiers.Remove(dossier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DossierExists(int id)
        {
            return _context.dossiers.Any(e => e.DossierId == id);
        }
    }
}
