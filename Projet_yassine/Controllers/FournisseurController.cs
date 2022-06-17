using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet_yassine.Models;
using Projet_yassine.Models.Repositories;

namespace Projet_yassine.Controllers
{
    public class FournisseurController : Controller
    {
        readonly IFournisseurRepository FournisseurRepository;
        public FournisseurController(IFournisseurRepository FournisseurRepository)
        {
            this.FournisseurRepository = FournisseurRepository;
        }
        // GET: FournisseurController
        public ActionResult Index()
        {
            return View(FournisseurRepository.GetAll());
        }

        // GET: FournisseurController/Details/5
        public ActionResult Details(int id)
        {
            var fourn = FournisseurRepository.GetById(id);
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
        public ActionResult Create(Fournisseur fourn)
        {
            try
            {
                FournisseurRepository.Add(fourn);
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
            var fourn = FournisseurRepository.GetById(id);
            return View(fourn);
        }

        // POST: FournisseurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fournisseur fourn)
        {
            try
            {
                FournisseurRepository.Edit(fourn);
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
            var fourn = FournisseurRepository.GetById(id);
            return View(fourn);
        }

        // POST: FournisseurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fournisseur fourn)
        {
            try
            {
                FournisseurRepository.Delete(fourn);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
