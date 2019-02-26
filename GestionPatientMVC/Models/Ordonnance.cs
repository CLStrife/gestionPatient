using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionPatientMVC.Models
{
    public class Ordonnance
    {
        private int id;
        private DateTime datePrescription;
        private int idPatient;
        private string lesMedics;

        public DateTime DatePrescription { get => datePrescription; set => datePrescription = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public int Id { get => id; set => id = value; }
        public string LesMedics { get => lesMedics; set => lesMedics = value; }

        public static List<Ordonnance> GetlstOrdonnance()
        {
            List<Ordonnance> laListe = new List<Ordonnance>();
            string req = "select * from ordonnance";
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    Ordonnance o = new Ordonnance();
                    o.Id = (int)res["idOrdonnance"];
                    o.DatePrescription = Convert.ToDateTime(res["dateOrdonnance"]);
                    o.IdPatient = (int)res["idPatient"];
                    o.LesMedics = res["listMedic"].ToString();
                    laListe.Add(o);
                }
            }
            return laListe;
        }
        public static Ordonnance consulterOrdonnance(int id)
        {
            Ordonnance o = new Ordonnance();
            string req = "select * from ordonnance where idOrdonnance=" + id;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    o.IdPatient         = (int)res["idPatient"];
                    o.DatePrescription  = Convert.ToDateTime(res["dateOrdonnance"]);
                    o.LesMedics = res["listMedic"].ToString(); 
                }
            }
            return o;
        }

        public static Ordonnance setDate()
        {
            Ordonnance o = new Ordonnance();
            o.DatePrescription = DateTime.Today;
            return o;
        }

        public bool ajouterOrdonnance()
        {
            string req = "insert into ordonnance(dateOrdonnance, idPatient, listMedic)" +
                    " values('" + this.DatePrescription + 
                    "', " + this.IdPatient + 
                    "', " + this.LesMedics + "')";
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

        public bool modifierOrdonnance()
        {
            string reqModifier = "update ordonnance set " +
                "idPatient= '" + this.IdPatient +
                "', dateOrdonnance= '" + this.DatePrescription +
                "', listMedic='" + this.LesMedics +
                "' where idOrdonnance =" + this.Id;
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
    }
}