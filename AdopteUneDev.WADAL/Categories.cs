using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL
{
    public class Categories
    {
        #region Fields
        /// <summary>
        /// Identifiant unique de la catégorie
        /// </summary>
        private int _idCategory;
        /// <summary>
        /// Nom de la catégorie
        /// </summary>
        private string _categLabel;
        /// <summary>
        /// Liste des langues de la catégorie
        /// </summary>
        private List<ITLang> _itLangs;        
        #endregion
        #region Properties
        public int IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }
        public string CategLabel
        {
            get { return _categLabel; }
            set { _categLabel = value; }
        }
        /// <summary>
        /// Navigation property permettant de récupérer la liste des languages
        /// associés à la catégorie
        /// </summary>
        public List<ITLang> ItLangs 
        {
            get {

                if (_itLangs == null)
                    _itLangs = ChargerLesITLangs();

                return _itLangs;

                // return _itLangs=_itLangs?? ChargerLesITLangs();            
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Permet de charger les langues associées à la catégorie courante
        /// </summary>
        /// <returns>une liste contenant les langues associées à la catégorie courante</returns>
        private List<ITLang> ChargerLesITLangs()
        {
            string query = @"select * from ITLang  i
                            inner join LangCateg c
                            on c.idIT = i.idIT
                            where c.idCategory =" + this.IdCategory;
            List<ITLang> retour = new List<ITLang>();
            List<Dictionary<string, object>> MesLangs = GestionConnexion.Instance.getData(query);
            foreach (Dictionary<string, object> item in MesLangs)
            {
                ITLang l = new ITLang();
                l.IdIT = (int)item["idIT"];
                l.ITLabel = item["ITLabel"].ToString();
                retour.Add(l);
            }

            return retour;

        }

        #region Statiques

        /// <summary>
        /// Permet de charger une catégorie de la DB via sa clé primaire
        /// </summary>
        /// <param name="idCateg">Identifiant unique de la catégorie</param>
        /// <returns>la catégorie correspondante</returns>
        public static Categories ChargerUneCategorie(int idCateg)
        {
            List<Dictionary<string, object>> UneCat = GestionConnexion.Instance.getData("select * from Categories where idCategory=" + idCateg);
            Categories cat = Associe(UneCat[0]);
            return cat;
        }
        /// <summary>
        /// Permet de charger la liste complète de toutes les catégories en DB
        /// </summary>
        /// <returns>la liste complète de toutes les catégories en DB</returns>
        public static List<Categories> ChargerToutesLesCategories()
        {
            List<Categories> retour = new List<Categories>();
            List<Dictionary<string, object>> LesCat = GestionConnexion.Instance.getData("select * from Categories");
            foreach (Dictionary<string, object> item in LesCat)
            {
                retour.Add(Associe(item));
            }
            return retour;

            //Elise TDM PRESENTE
            //En une ligne pour se la peter!!!! 
            //Happy birtday!
            //return GestionConnexion.Instance.getData("select * from Categories").Select(el => Associe(el)).ToList();


        }
        /// <summary>
        /// Permet d'associer les infos récupérées de la DB avec les propriété d'une catégorie
        /// </summary>
        /// <param name="UneCat">Un dictionnaire contenant les données BD</param>
        /// <returns>La catégorie remplie</returns>
        private static Categories Associe(Dictionary<string, object> UneCat)
        {
            Categories cat = new Categories();
            cat.IdCategory = (int)UneCat["idCategory"];
            cat.CategLabel = UneCat["CategLabel"].ToString();
            return cat;
        }
        
        #endregion
        #endregion
    }
}
