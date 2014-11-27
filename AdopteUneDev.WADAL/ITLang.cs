using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL
{
    public class ITLang
    {
        #region Fields
        /// <summary>
        /// Identifiant unique de l'ITLang
        /// </summary>
        private int _idIT;
        /// <summary>
        /// Nom de l'ITLAng
        /// </summary>
        private string _iTLabel;
          /// <summary>
          /// Liste des catégories associée à l'ITLang courante
          /// </summary>
        private List<Categories> _categories; 
        #endregion
        #region Properties
        /// <summary>
        /// NAvigation properties permettant de récupérer les catégories de l'ITLang courante
        /// </summary>
        public List<Categories> Categories
        {
            get { return _categories = _categories ?? ChargerLesCategories(); }
        }
        /// <summary>
        /// Propriété permettant de récupérer le nom du language
        /// </summary>
        public string ITLabel
        {
            get { return _iTLabel; }
            set { _iTLabel = value; }
        }
       /// <summary>
       /// Propriété permettant de récupérer l'identifiant unique
       /// </summary>
        public int IdIT
        {
            get { return _idIT; }
            set { _idIT = value; }
        } 
        #endregion
        #region Functions
        /// <summary>
        /// Permet de charger la liste des catégories associées à l'ITLang courante
        /// </summary>
        /// <returns>la liste des catégories associées à l'ITLang courante</returns>
        private List<WADAL.Categories> ChargerLesCategories()
        {
            string query = @"select * from Categories c
                            inner join LangCateg l 
                            on c.idCategory = l.idCategory
                            where l.idIT =" + this.IdIT;
            List<WADAL.Categories> retour = new List<WADAL.Categories>();
            List<Dictionary<string, object>> MesCat = GestionConnexion.Instance.getData(query);
            foreach (Dictionary<string, object> item in MesCat)
            {
                Categories cat = new Categories();
                cat.IdCategory = (int)item["idCategory"];
                cat.CategLabel = item["CategLabel"].ToString();
                retour.Add(cat);
            }

            return retour;

        }
        #region Static
        /// <summary>
        /// Permet de charger une ITLang de la DB via sa clé primaire
        /// </summary>
        /// <param name="idit">Identifiant unique de l' ITLang</param>
        /// <returns>l'ITLang correspondante</returns>
        public static ITLang ChargerUneITLang(int idit)
        {
            List<Dictionary<string, object>> UneItLang = GestionConnexion.Instance.getData("select * from ITLang where idIT=" + idit);
            ITLang lan = Associe(UneItLang[0]);
            return lan;
        }
        /// <summary>
        /// Permet de charger la liste complète de toutes les ITLang en DB
        /// </summary>
        /// <returns>la liste complète de toutes les ITLang en DB</returns>
        public static List<ITLang> ChargerToutesLesITLang()
        {
            List<ITLang> retour = new List<ITLang>();
            List<Dictionary<string, object>> LesLang = GestionConnexion.Instance.getData("select * from ITLang");
            foreach (Dictionary<string, object> item in LesLang)
            {
                retour.Add(Associe(item));
            }
            return retour;

        }
        /// <summary>
        /// Permet d'associer les infos récupérées de la DB avec les propriété d'une ITLang
        /// </summary>
        /// <param name="UneItLang">Un dictionnaire contenant les données BD</param>
        /// <returns>L'ITLang remplie</returns>
        private static ITLang Associe(Dictionary<string, object> UneItLang)
        {
            ITLang lan = new ITLang();
            lan.IdIT = (int)UneItLang["idIT"];
            lan.ITLabel = UneItLang["ITLabel"].ToString();
            return lan;
        }  
        #endregion
        #endregion
    
    }
}
