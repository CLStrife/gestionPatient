using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static List<Patient> GetLstPatient()
        {
            List<Patient> laListe = new List<Patient>();
            string req = "select * from patient";
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    Patient p = new Patient();
                    p.Id = (int)res["id"];
                    p.Nom = res["nom"].ToString();
                    p.Prenom = res["prenom"].ToString();
                    p.Genre = Convert.ToChar(res["genre"]);
                    p.Adr = res["adr1"].ToString();
                    p.Ville = res["ville"].ToString();
                    p.Pays = res["pays"].ToString();
                    laListe.Add(p);
                }
            }
            return laListe;
        }

        public static Patient consulterPatient(int id)
        {
            Patient p = new Patient();
            string req = "select * from patient where id=" + id;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    p.Id = (int)res["id"];
                    p.Nom = res["nom"].ToString();
                    p.Prenom = res["prenom"].ToString();
                    p.Genre = Convert.ToChar(res["genre"]);
                    p.Adr = res["adr1"].ToString();
                    p.Ville = res["ville"].ToString();
                    p.Pays = res["pays"].ToString();
                }
            }
            return p;
        }

        public bool ajouterPatient()
        {
            string req = "insert into patient(nom, prenom, genre, adr1, ville, pays)" +
                    " values('" + this.Nom +
                    "', '" + this.Prenom +
                    "', '" + this.Genre +
                    "', '" + this.Adr +
                    "', '" + this.Ville +
                    "', '" + this.Pays + "')";
            int reponse = ParametresBD.executeMajBD(req);
            if (reponse > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool modifierPatient()
        {
            string reqModifier = "update patient set " +
                "nom= '"        + this.Nom +
                "', prenom= '"  + this.Prenom +
                "', genre='"    + this.Genre +
                "', adr1= '"    + this.Adr +
                "', ville= '"   + this.Ville +
                "', pays= '"    + this.Pays +
                "' where id ="  + this.Id;
            int reponse = ParametresBD.executeMajBD(reqModifier);
            if (reponse > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool supprimerPatient(int id)
        {
            // supprimer les participations de cet étudiant aux cours
            string req = "delete from visite " +
                         "where idPatient=" + id;
            int rep =
                ParametresBD.executeMajBD(req);
            // supprimer définitivement l'étudiant
            string reqSuppPatient = "delete from patient " +
                                                "where id=" + id;
            int reponseSuppr = ParametresBD.executeMajBD(reqSuppPatient);
            if (reponseSuppr > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}