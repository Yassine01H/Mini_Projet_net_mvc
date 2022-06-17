using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projet_yassine.Models;
using Projet_yassine.Models.Repositories;

namespace Projet_yassine.Controllers
{
    public class ProduitController : Controller
    {
        readonly IProduitRepository ProduitRepository;
        readonly IFournisseurRepository FournisseurRepository;
        readonly ICategorieProduitRepository CategorieProduitRepository;
        public ProduitController(IProduitRepository ProduitRepository, IFournisseurRepository FournisseurRepository, ICategorieProduitRepository CategorieProduitRepository)
        {
            this.ProduitRepository = ProduitRepository;
            this.FournisseurRepository = FournisseurRepository;
            this.CategorieProduitRepository = CategorieProduitRepository;
        }
        // GET: StudentController
  
        public ActionResult Index()
        {
            ViewBag.CategorieProduitID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitID", "CategorieProduitName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View(ProduitRepository.GetAll());
        }
        public ActionResult Search(string name, int? CategorieProduitiD)
        {
            var result = ProduitRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = ProduitRepository.FindByName(name);
            else
            if (CategorieProduitiD != null)
                result = ProduitRepository.GetProduitByCategorieProduitID(CategorieProduitiD);
            ViewBag.CategorieProduitID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitRepository", "CategorieProduitName");
            return View("Index", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(ProduitRepository.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.CategorieProduitID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitID", "CategorieProduitName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit p)
        {
            try
            {
                ViewBag.CategorieProduitID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitID", "CategorieProduitName", p.CategorieProduitID);
                ProduitRepository.Add(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorieProduitID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitID", "CategorieProduitName");
            return View(ProduitRepository.GetById(id));
        }
        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit p)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(CategorieProduitRepository.GetAll(), "CategorieProduitID", "CategorieProduitName");
                ProduitRepository.Edit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ProduitRepository.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produit p)
        {
            try
            {
                ProduitRepository.Delete(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
