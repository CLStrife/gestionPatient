using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionPatientMVC.Models
{
    public class ListMedicament
    {
        private int idMedic;
        private int idOrdonnance;
        private List<Medicament> lstMedicament;
        private List<Ordonnance> lstOrdonnance;

        public int IdMedic { get => idMedic; set => idMedic = value; }
        public int IdOrdonnance { get => idOrdonnance; set => idOrdonnance = value; }
        public List<Medicament> LstMedicament { get => lstMedicament; set => lstMedicament = value; }
        public List<Ordonnance> LstOrdonnance { get => lstOrdonnance; set => lstOrdonnance = value; }

        public static List<Medicament> getLstMedic(int id)
        {
            List<Medicament> laListe = new List<Medicament>();
            string req = "select nomMedic from medicament " +
                "JOIN list_medic on medicament.idMedic = list_medic.idMedic " +
                "where list_idOrdonnance=" + id;
            SqlDataReader res = ParametresBD.executeSelect(req);
            if (res != null && res.HasRows == true)
            {
                while (res.Read())
                {
                    Medicament m = new Medicament();
                    m.Id = (int)res["idMedic"];
                    m.NomMedic = res["nomMedic"].ToString();
                    laListe.Add(m);
                }
            }
            return laListe;
        }
    }
}