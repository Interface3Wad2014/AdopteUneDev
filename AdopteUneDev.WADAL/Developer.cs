using System;
using System.Collections.Generic;

namespace AdopteUneDev.WADAL
{
    /// <summary>
    /// Classe représentant un developeur
    /// </summary>
     public class Developer
    {
        #region Fields
         /// <summary>
         /// Identifiant unique du developpeur
         /// </summary>
        private int _idDev;
         /// <summary>
         /// Nom du developpeur
         /// </summary>
        private string _devName;
         /// <summary>
         /// Prénom du developpeur
         /// </summary>
        private string _devFirstName;
         /// <summary>
         /// Date de naissance du developpeur
         /// </summary>
        private DateTime _devBirthDate;
         /// <summary>
         /// Chemin vers la photo du développeur
         /// </summary>
        private string _devPicture;
         /// <summary>
         /// Coût horaire du developpeur
         /// </summary>
        private double _devHourCost;
         /// <summary>
         /// Coût journalier du développeur
         /// </summary>
        private double _devDayCost;
        /// <summary>
        /// Coût mensuel du développeur
        /// </summary>
        private double _dvMonthCost;
         /// <summary>
         /// Mail du développeur
         /// </summary>
        private string _devMail; 
        #endregion
        #region Properties
         /// <summary>
         /// propriété permettant de récupérer l'identifiant unique du developpeur
         /// </summary>
		 public int IdDev { get { return _idDev; } set { _idDev = value; } }
         /// <summary>
         /// propriété permettant de récupérer le nom du developpeur
         /// </summary>
         public string DevName { get { return _devName; } set { _devName = value; } }
         /// <summary>
         /// propriété permettant de récupérer le prénom du developpeur
         /// </summary>
         public string DevFirstName { get { return _devFirstName; } set { _devFirstName = value; } }
         /// <summary>
         /// propriété permettant de récupérer la date de naissance du developpeur
         /// </summary>
         public DateTime DevBirthDate { get { return _devBirthDate; } set { _devBirthDate = value; } }
         /// <summary>
         /// propriété permettant de récupérer le chemin vers la photo du developpeur
         /// </summary>
         public string DevPicture { get { return _devPicture; } set { _devPicture = value; } }
         /// <summary>
         /// propriété permettant de récupérer le coût horaire du developpeur
         /// </summary>
         public double DevHourCost { get { return _devHourCost; } set { _devHourCost = value; } }
         /// <summary>
         /// propriété permettant de récupérer le coût journalier du developpeur
         /// </summary>
         public double DevDayCost { get { return _devDayCost; } set { _devDayCost = value; } }
         /// <summary>
         /// propriété permettant de récupérer le coût mensuel du developpeur
         /// </summary>
         public double DevMonthCost { get { return _dvMonthCost; } set { _dvMonthCost = value; } }
         /// <summary>
         /// propriété permettant de récupérer le mail du developpeur
         /// </summary>
         public string DevMail { get { return _devMail; } set { _devMail = value; } }
        #endregion
         #region Functions
         /// <summary>
         /// Peremet de récupérer la totalité des développeurs
         /// </summary>
         /// <returns>Une liste de Developer</returns>
         public static List<Developer> ChargerTousLesDev()
         {
             List<Dictionary<string, object>> lstDevs =
                 GestionConnexion.Instance.getData("select * from Developer");
             List<Developer> retour = new List<Developer>();
             foreach (Dictionary<string, object> item in lstDevs)
             {
                 Developer dev = Associe(item);
                 retour.Add(dev);
             }
             return retour;
         }
         /// <summary>
         /// Permet de récupérer 1 developpeur à partir de son ID
         /// </summary>
         /// <param name="idD">Id du developpeur a charger</param>
         /// <returns>Le developpeur</returns>
         public static Developer ChargerUnDev(int idD)
         {
             List<Dictionary<string, object>> UnDev =
             GestionConnexion.Instance.getData("select * from Developer where idDev=" + idD);
             Developer dev = Associe(UnDev[0]);
             return dev;
         }
         /// <summary>
         /// Permet d'associer les champs du dictionnaire aux propriétés correspondantes
         /// </summary>
         /// <param name="item">Un dictionnaire (nom col, valeur)</param>
         /// <returns></returns>
         private static Developer Associe(Dictionary<string, object> item)
         {
             Developer dev = new Developer()
                {
                    IdDev = (int)item["idDev"],
                    DevName = item["DevName"].ToString(),
                    DevFirstName = item["DevFirstName"].ToString(),
                    DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString()),
                    DevDayCost = (double)item["DevDayCost"],
                    DevMail = item["DevMail"].ToString(),
                    DevHourCost = (double)item["DevHourCost"],
                    DevMonthCost = (double)item["DevMonthCost"],
                    DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString()
                };
             return dev;
         }
        
         #endregion
     }
}
