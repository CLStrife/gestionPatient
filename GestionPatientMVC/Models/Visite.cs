using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace GestionPatientMVC.Models
{
    public class Visite
    {
        private int id;
        private DateTime dateVisite;
        private TimeSpan heureVisite;
        private int idPatient;
        private string typeVisite;

        public int Id { get => id; set => id = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public string TypeVisite { get => typeVisite; set => typeVisite = value; }
        public DateTime DateVisite { get => dateVisite; set => dateVisite = value; }
        public TimeSpan HeureVisite { get => heureVisite; set => heureVisite = value; }


        public static List<Visite>GetlstVisite(int id)
        {
            List<Visite> laListe = new List<Visite>();
            string req = "select * from visite where idPatient=" +id;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    Visite v        = new Visite();
                    v.Id            = (int)res["idVisite"];
                    v.DateVisite    = Convert.ToDateTime(res["dateVisite"]);
                    v.TypeVisite    = res["typeVisite"].ToString();
                    v.HeureVisite   = (TimeSpan)res["heureVisite"];
                    v.IdPatient     = (int)res["idPatient"];
                    laListe.Add(v);
                }
            }
            return laListe;
        }

        public static List<Visite> GetLstVisiteJours(DateTime laDate)
        {
            List<Visite> laListe = new List<Visite>();
            string req = "select * from visite where dateVisite= "+laDate;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    Visite v = new Visite();
                    v.id            = (int)res["idVisite"];
                    v.DateVisite    = Convert.ToDateTime(res["dateVisite"]);
                    laListe.Add(v);
                }
            }
            return laListe;
        }

        public bool ajouterUneVisite()
        {
            string req = "insert into visite(dateVisite, idPatient, typeVisite, heureVisite)" +
                "values('" + 
                this.DateVisite +
                "', " + this.IdPatient +
                ", '" + this.TypeVisite +
                "', '" + this.HeureVisite + "')";
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

        public static Visite consulterVisite(int id)
        {
            Visite v = new Visite();
            string req = "select * from Visite where idVisite=" + id;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    v.Id = (int)res["idVisite"];
                    v.DateVisite = Convert.ToDateTime(res["dateVisite"]);
                    v.TypeVisite = res["typeVisite"].ToString();
                    v.HeureVisite = (TimeSpan)res["heureVisite"];
                    v.IdPatient = (int)res["idPatient"];
                }
            }
            return v;
        }

        public bool modifierVisite()
        {
            string req = "update visite set " +
                "dateVisite='"+ this.DateVisite + 
                "', typeVisite='" + this.TypeVisite +
                "', heureVisite='"+ this.HeureVisite+
                "' where idVisite=" + this.Id;
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
        public bool supprimerLaVisite()
        {
            // supprimer les participations de cet étudiant aux cours
            string req = "delete from visite " +
                         "where idVisite=" + this.Id;
            int rep = ParametresBD.executeMajBD(req);
          
            if (rep > 0)
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