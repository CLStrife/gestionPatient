using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionPatientMVC.Models
{
    public class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private char genre;
        private string adr;
        private string ville;
        private string pays;
        private List<Visite> lstVisite;
        private List<Ordonnance> lstOrdonnance;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public List<Visite> LstVisite { get => lstVisite; set => lstVisite = value; }
        public List<Ordonnance> LstOrdonnance { get => lstOrdonnance; set => lstOrdonnance = value; }
        public char Genre { get => genre; set => genre = value; }
        public string Adr { get => adr; set => adr = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Pays { get => pays; set => pays = value; }

        public List<Patient> GetLstPatient()
        {

            return null;
        }
    }
}