using GestionPatientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionPatientMVC.Controllers
{
    public class OrdonnanceController : Controller
    {
        // GET: Ordonnance
        public ActionResult Index()
        {
            List<Ordonnance> lstOrdonnance = Ordonnance.GetlstOrdonnance();
            return View(lstOrdonnance);
        }

        // GET: Ordonnance/Details/5
        public ActionResult Details(int id)
        {
            Ordonnance o = Ordonnance.consulterOrdonnance(id);
            return View(o);
        }

        // GET: Ordonnance/Create
        public ActionResult Create()
        {
            Ordonnance o = Ordonnance.setDate();
            return View(o);
        }

        // POST: Ordonnance/Create
        [HttpPost]
        public ActionResult Create(Ordonnance nouvelOrdonnance)
        {
            try
            {
                // TODO: Add insert logic here
                bool etat = nouvelOrdonnance.ajouterOrdonnance();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ordonnance/Edit/5
        public ActionResult Edit(int id)
        {
            Ordonnance ordonnanceModifier = Ordonnance.consulterOrdonnance(id);
            return View(ordonnanceModifier);
        }

        // POST: Ordonnance/Edit/5
        [HttpPost]
        public ActionResult Edit(Ordonnance ordonnanceModifier)
        {
            try
            {
                // TODO: Add update logic here
                bool response = ordonnanceModifier.modifierOrdonnance();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ordonnance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ordonnance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
