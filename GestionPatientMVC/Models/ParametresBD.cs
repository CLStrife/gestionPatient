using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionPatientMVC.Models
{ 

    public class ParametresBD
    {
        // attributs=champs
        private static readonly string chaineConnexionNorthwind =
            "integrated security=SSPI;data source=MONDITL002\\SQLEXPRESS;"
            + "persist security info=false;initial catalog=Medical";

        public static string ChaineConnexionNorthwind => chaineConnexionNorthwind;
        // propriétés = setters + getteurs
        // sélectionner les champs et faire Ctril+R+E

        // méthodes
        //  méthode pour les Select SQL
        public static SqlDataReader executeSelect(string laRequete)
        {
            SqlConnection laConnexion;          // pour établir une connexion
            SqlCommand laCommandeSQL;           // pour éxéxuter une commande SQL
            SqlDataReader resultatsSQL;         // pour récup. résultat d'un Select SQL
                                                // je me connecte 
            laConnexion = new SqlConnection();
            laConnexion.ConnectionString = ChaineConnexionNorthwind;
            try
            {
                laConnexion.Open();
                laCommandeSQL = new SqlCommand(laRequete, laConnexion);
                resultatsSQL = laCommandeSQL.ExecuteReader();
                return resultatsSQL;
            }
            catch(Exception exp)
            {
                return null;
            }
        } // fin executeSelect
        public static int executeMajBD(string requeteMaj)
        {
            // méthode pour Insert, Delete ou Update en SQL
            SqlConnection laConnexion;          // pour établir une connexion
            SqlCommand laCommandeSQL;           // pour éxéxuter une commande SQL
            
            laConnexion = new SqlConnection();
            laConnexion.ConnectionString = ChaineConnexionNorthwind;
            try
            {
                laConnexion.Open();
                laCommandeSQL = new SqlCommand(requeteMaj, laConnexion);
                int nbreLignesImpactees = laCommandeSQL.ExecuteNonQuery();
                return nbreLignesImpactees;
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
    }
}
