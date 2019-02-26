using GestionPatientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionPatientMVC.Controllers
{
    public class VisiteController : Controller
    {
        // GET: Visite
        public ActionResult Index(int id)
        {
            List<Visite> lstVisite = Visite.GetlstVisite(id);
            return View(lstVisite);
        }


        // GET: Visite/Details/5
        public ActionResult Details(int id)
        {
            Visite laVisite = Visite.consulterVisite(id);
            return View(laVisite);
        }

        // GET: Visite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visite/Create
        [HttpPost]
        public ActionResult Create(Visite infoVisite )
        {
            try
            {
                // TODO: Add insert logic here
                bool etat = infoVisite.ajouterUneVisite();

                return RedirectToAction("Index", new { id = infoVisite.IdPatient });
            }
            catch
            {
                return View();
            }
        }

        // GET: Visite/Edit/5
        public ActionResult Edit(int id)
        {
            Visite modifVisite  = Visite.consulterVisite(id);
            return View(modifVisite);
        }

        // POST: Visite/Edit/5
        [HttpPost]
        public ActionResult Edit(Visite visiteModifer)
        {
            try
            {
                // TODO: Add update logic here
                bool response = visiteModifer.modifierVisite();
                return RedirectToAction("Index", new { id = visiteModifer.IdPatient });
            }
            catch
            {
                return View();
            }
        }

        // GET: Visite/Delete/5
        public ActionResult Delete(int id)
        {
            Visite visite = Visite.consulterVisite(id);
            return View(visite);
        }

        // POST: Visite/Delete/5
        [HttpPost]
        public ActionResult Delete(Visite visiteSupp)
        {
            try
            {
                // TODO: Add delete logic here
                bool repSuppress = visiteSupp.supprimerLaVisite();
                return RedirectToAction("Index", new { id = visiteSupp.IdPatient });
            }
            catch
            {
                return View();
            }
        }
    }
}
