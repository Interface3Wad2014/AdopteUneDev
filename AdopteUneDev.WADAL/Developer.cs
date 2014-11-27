using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL
{
    /// <summary>
    /// Classe représentant un developeur
    /// </summary>
     public class Developer
    {
        #region Fields
        private int _idDev;
        private string _devName;
        private string _devFirstName;
        private DateTime _devBirthDate;
        private string _devPicture;
        private double _devHourCost;
        private double _devDayCost;
        private double _dvMonthCost;
        private string _devMail; 
        #endregion
        #region Properties
		 public int IdDev { get { return _idDev; } set { _idDev = value; } }
         public string DevName { get { return _devName; } set { _devName = value; } }
         public string DevFirstName { get { return _devFirstName; } set { _devFirstName = value; } }
         public DateTime DevBirthDate { get { return _devBirthDate; } set { _devBirthDate = value; } }
         public string DevPicture { get { return _devPicture; } set { _devPicture = value; } }
         public double DevHourCost { get { return _devHourCost; } set { _devHourCost = value; } }
         public double DevDayCost { get { return _devDayCost; } set { _devDayCost = value; } }
         public double DevMonthCost { get { return _dvMonthCost; } set { _dvMonthCost = value; } }
         public string DevMail { get { return _devMail; } set { _devMail = value; } }
        #endregion
    
         /// <summary>
         /// Peremet de récupérer la totalité des développeurs
         /// </summary>
         /// <returns>Une liste de Developer</returns>
         public static List<Developer> ChargerTousLesDev()
         {
             List<Dictionary<string,object>> lstDevs = 
                 GestionConnexion.Instance.getData("select * from Developer");
             List<Developer> retour = new List<Developer>();
             foreach (Dictionary<string,object> item in lstDevs)
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
                    DevBirthDate=DateTime.Parse(item["DevBirthDate"].ToString()),
                    DevDayCost = (double)item["DevDayCost"],
                    DevMail= item["DevMail"].ToString(),
                    DevHourCost= (double)item["DevHourCost"],
                    DevMonthCost=(double)item["DevMonthCost"],
                    DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString()
                };
             return dev;
         }
        
     }
}
