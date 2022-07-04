using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aaa.Data;
using aaa.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace aaa.Controllers
{
    
    public class DossiersController : Controller
    {
        private readonly AppDbContext _context;

        public DossiersController(AppDbContext context)
        {
            _context = context;
        }
        //etat De post réponse
        
        public async Task<IActionResult> Employe(string searchString)
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
        
        // GET: Dossiers
        //[/*Authorize*/]
        //etat creation
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var t = _context.dossiers.Select(ds => ds).Where(ds => ds.Etat == "création").ToListAsync();
            return View(await t);
        }
        
        //etat De post réponse
        public async Task<IActionResult> Employee()
        {

           
            List<AttestionTravail> AttestionTravails;
            List<AttestionDeSalaire> AttestionDeSalaires;
            var t = _context.dossiers.Select(ds => ds).Where(ds => ds.Etat == "Attende la notification").ToListAsync();
            return View(await t);
        }
        //// GET: List Dossiers no tarméni
        public async Task<IActionResult> DossiersNT(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            List<AttestionTravail> AttestionTravails;
            List<AttestionDeSalaire> AttestionDeSalaires;
            var students = _context.dossiers.Select(ds => ds).Where(ds => ds.Etat == "Attende la reponse").Select(emp => emp);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.EmployeeName.Contains(searchString)
                                       || s.EmployeePrenom.Contains(searchString));
            }

            
            return View(students);
        }
        //// GET: List Dossiers no tarméni
        public async Task<IActionResult> DossiersAR(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            List<AttestionTravail> AttestionTravails;
            List<AttestionDeSalaire> AttestionDeSalaires;
            var students = _context.dossiers.Select(ds => ds).Where(ds => ds.Etat == "état de post-réponse").Select(emp => emp);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.EmployeeName.Contains(searchString)
                                       || s.EmployeePrenom.Contains(searchString));
            }
            
            return View(students);
        }
        // GET: List Dossiers tarméni
        public async Task<IActionResult> DossiersT(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            List<AttestionTravail> AttestionTravails;
            List<AttestionDeSalaire> AttestionDeSalaires;
            List<AttestionDeCesseison> AttestionDeCesseisons;

            var students = _context.dossiers.Select(ds => ds).Where(ds => ds.Etat == "Etat retraite").Select(emp => emp);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.EmployeeName.Contains(searchString)
                                       || s.EmployeePrenom.Contains(searchString));
            }
            
            return View(students);
        }
        // GET: Dossiers/Details/5
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
        // GET: Details Attestion Travails
        public IActionResult DetailsAttestionTravails(int? Id)
        {
            if (Id == null || _context.AttestionTravails == null)
            {
                return NotFound();
            }
            var DAT = _context.dossiers.Include(e => e.AttestionTravails).Where(predicate: a => a.DossierId == Id).FirstOrDefault();
            if (_context.AttestionTravails == null)
            {
                return NotFound();
            }
            return View(DAT);

        }
        // GET: Details Attestion De Salaire
        public IActionResult DetailsAttestionDeSalaires(int Id)
        {
            if (Id == null || _context.AttestionDeSalaires == null)
            {
                return NotFound();
            }
            var DAT = _context.dossiers.Include(e => e.AttestionDeSalaires).Where(predicate: a => a.DossierId == Id).FirstOrDefault();
            if (_context.AttestionDeSalaires == null)
            {
                return NotFound();
            }
            return View(DAT);

        }
        // GET: Details Attestion De Cesseison
        public IActionResult DetailsAttestionDeCesseison(int Id)
        {
            if (Id == null || _context.AttestionDeCesseisons == null)
            {
                return NotFound();
            }
            var DAT = _context.dossiers.Include(e => e.AttestionDeCesseisons).Where(predicate: a => a.DossierId == Id).FirstOrDefault();
            if (_context.AttestionDeCesseisons == null)
            {
                return NotFound();
            }
            return View(DAT);

        }
        // GET: Details AttestionTravails
        public async Task<IActionResult> DetailsAttestionTravailsA(int? id)
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


        // GET: Dossiers/Create
        public IActionResult Create()
        {
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
            return View();
        }

        // POST: Dossiers/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DossierId,EmployeeName,EmployeePrenom,DeteNaissance,Address,NaissanceWilaya,Qualite,NomeParronPere,PrenomParronPere,NomeParronmere,PrenomParronmere,NumeroAllocationFamilailes,NumeroAllocationAssure,NumeroSocialesFamilailes,NumeroSocialesAssure,DubutTravail,FinTravail,Etat")] Dossier dossier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dossier);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employe", "Dossiers");
            }
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
            return View(dossier);
        }
        public async Task<IActionResult> creatmut(int id)
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
        [HttpPost]
        public IActionResult creatmut(Dossier dossier)
        {
            dossier.AttestionTravails.RemoveAll(n => n.SalaireSoumisCotisation == 0);
            dossier.AttestionDeSalaires.RemoveAll(n => n.SalaireSoumisRetenue == 0);

            _context.Add(dossier);
            _context.SaveChanges();
            return RedirectToAction("Employe", "Dossiers");
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };



        }
        [HttpGet]
        public IActionResult CreateAttestionTravaill()
        {
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };

            AttestionTravail attestionTravail = new AttestionTravail();
            AttestionDeSalaire attestionDeSalaire = new AttestionDeSalaire();
            Dossier dossier = new Dossier();
            dossier.AttestionTravails.Add(new AttestionTravail() { AttestionTravailId = 1 });
            dossier.AttestionDeSalaires.Add(new AttestionDeSalaire() { AttestionDeSalaireId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });
            return View(dossier);
        }


        [HttpPost]
        public IActionResult CreateAttestionTravaill(Dossier dossier)
        {
            dossier.AttestionTravails.RemoveAll(n => n.SalaireSoumisCotisation == 0);
            dossier.AttestionDeSalaires.RemoveAll(n => n.SalaireSoumisRetenue == 0);

            _context.Add(dossier);
            _context.SaveChanges();
            return RedirectToAction("Employe", "Dossiers");
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };



        }
        //[HttpGet]
        //public IActionResult CreateAttestionTravaill()
        //{
        //    AttestionTravail attestionTravail = new AttestionTravail();
        //    Dossier dossier = new Dossier();

        //    dossier.AttestionTravails.Add(new AttestionTravail() { AttestionTravailId = 1 });


        //    ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "Address");


        //    return View();



        //}
        //[HttpPost]
        //public IActionResult CreateAttestionTravaill(Dossier dossier)
        //{
        //    dossier.AttestionTravails.RemoveAll(n => n.SalaireSoumisCotisation == 0);

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(dossier);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DossierId"] = new SelectList(_context.dossiers, "DossierId", "Address");
        //    return View("index");
        //}




        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
            if (id == null)
            {
                return NotFound();
            }

            var dossier = await _context.dossiers.FindAsync(id);
            if (dossier == null)
            {
                return NotFound();
            }
            return View(dossier);
        }

        // POST: Dossiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DossierId,EmployeeName,EmployeePrenom,DeteNaissance,Address,NaissanceWilaya,Qualite,NomeParronPere,PrenomParronPere,NomeParronmere,PrenomParronmere,NumeroAllocationFamilailes,NumeroAllocationAssure,NumeroSocialesFamilailes,NumeroSocialesAssure,DubutTravail,FinTravail,Etat")] Dossier dossier)
        {
            ViewBag.wilaia = new List<string>() { "Adrar", "Chlef", "Laghouat", "Oum_El_Bouaghi", "Batna", "Béjaïa", "Biskra", "Béchar", "Blida", "Bouira", "Tamanrasset", "Tébessa", "Tlemcen", "Tiaret", "Tizi_Ouzou", "Alger", "Djelfa", "Jijel", "Sétif", "Saïda", "Skikda", "Sidi_Bel_Abbès", "Annaba", "Guelma", "Constantine", "Médéa", "Mostaganem", "MSila", "Mascara", "Ouargla", "Oran", "Bayadh", "Illizi", "Bordj_Bou_Arreridj", "Boumerdès", "Tarf", "Tindouf", "Tissemsilt", "El_Oued", "Khenchela", "Souk_Ahras", "Tipaza", "Mila", "Defla", "Naâma", "Aïn_Témouchent", "Ghardaïa", "Relizane", "Timimoun", "Bordj_Badji_Mokhtar", "Ouled_Djellal", "Béni_Abbès", "Salah", "In_Guezzam", "Touggourt", "Djanet", "Ghair", "Meniaa" };
            ViewBag.etat = new List<string>() { "creation", "Attende la notification", "Attende la reponse", "état de post-réponse", "Etat retraite" };
            ViewBag.civilite = new List<string>() { "Mr", "Mme", "Melle" };
            ViewBag.Qualite = new List<string>() { "Agent d’exécution", "Cadre Moyen", "Cadre Supérieur", "Cardre Dirgeant" };
            ViewBag.safha = new List<string>() { "عون تنفيذ", "اطار", "اطار سامي", "اطار مسير" };
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
            return View(dossier);
        }
        public async Task<IActionResult> Editt(int? id)
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
        public async Task<IActionResult> Editt(int id, [Bind("DossierId,EmployeeName,EmployeePrenom,DeteNaissance,Adressedenaissence,Address,NaissanceWilaya,Titredecivilite,Lemployeursoussigné,NSSEMPLOYEUR,NASASSURE,Qualite,NumeroAllocationFamilailes,NumeroAllocationAssure,NumeroSocialesFamilailes,NumeroSocialesAssure,DubutTravail,FinTravail,nom,pre,ParronPere,Parronmere,makan,wilaia,mihna,onwan,safha,Etat")] Dossier dossier)
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
        // GET: Dossiers/Delete/5
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

        // POST: Dossiers/Delete/5
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
        [HttpGet]
        public IActionResult Editt(int Id)
        {
            
            Dossier applicant = _context.dossiers.Include(e => e.AttestionTravails).Where(a => a.DossierId == Id).FirstOrDefault();
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Editt(Dossier applicant)
        {
            List<AttestionTravail> expDetails = _context.AttestionTravails.Where(d => d.DossierId == applicant.DossierId).ToList();
            _context.AttestionTravails.RemoveRange(expDetails);
            _context.SaveChanges();

            applicant.AttestionTravails.RemoveAll(n => n.SalaireSoumisCotisation == 0);
            applicant.AttestionTravails.RemoveAll(n => n.IsDeleted == true);

            _context.Attach(applicant);
            _context.Entry(applicant).State = EntityState.Modified;
            _context.AttestionTravails.AddRange(applicant.AttestionTravails);

            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
