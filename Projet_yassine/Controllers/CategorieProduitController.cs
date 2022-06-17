using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet_yassine.Models;
using Projet_yassine.Models.Repositories;

namespace Projet_yassine.Controllers
{
    [Authorize]
    public class CategorieProduitController : Controller
    {
        readonly ICategorieProduitRepository CategorieProduitRepository;
        public CategorieProduitController(ICategorieProduitRepository CategorieProduitRepository)
        {
            this.CategorieProduitRepository = CategorieProduitRepository;
        }

        [AllowAnonymous]

        // GET: FournisseurController
        public ActionResult Index()
        {
            return View(CategorieProduitRepository.GetAll());
        }

        // GET: FournisseurController/Details/5
        public ActionResult Details(int id)
        {
            var fourn = CategorieProduitRepository.GetById(id);
            return View(fourn);
        }

        // GET: FournisseurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FournisseurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategorieProduit cat)
        {
            try
            {
                CategorieProduitRepository.Add(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FournisseurController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = CategorieProduitRepository.GetById(id);
            return View(cat);
        }

        // POST: FournisseurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategorieProduit cat)
        {
            try
            {
                CategorieProduitRepository.Edit(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FournisseurController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = CategorieProduitRepository.GetById(id);
            return View(cat);
        }

        // POST: FournisseurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategorieProduit cat)
        {
            try
            {
                CategorieProduitRepository.Delete(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
