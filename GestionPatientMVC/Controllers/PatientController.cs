using GestionPatientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionPatientMVC.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            List<Patient> lstPatient = Patient.GetLstPatient();
            return View(lstPatient);
        }
        public ActionResult getVisite(int id)
        {
            return RedirectToAction("Index", "VisiteController", id);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            Patient patient = Patient.consulterPatient(id);
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient infoPatient)
        {
            try
            {
                // TODO: Add insert logic here
                bool etat = infoPatient.ajouterPatient();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            Patient patientModifier = Patient.consulterPatient(id);
            return View(patientModifier);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(Patient patientModifier)
        {
            try
            {
                // TODO: Add update logic here
                bool response = patientModifier.modifierPatient();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            Patient patient = Patient.consulterPatient(id);
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bool repSuppress = Patient.supprimerPatient(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
