using AdopteUneDev.WADAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdopteUneDev.WADAL
{
    public class Client
    {
        #region Fields
            int _idClient;
            string _cliName;
            string _ciFirstName;
            string _cliMail;
            string _cliCompany;
            string _login;
        #endregion

        #region Properties
        public int IdClient
        {
            get { return _idClient; }
            set { _idClient = value; }
        }

        public string CliName
        {
            get { return _cliName; }
            set { _cliName = value; }
        }


        public string CiFirstName
        {
            get { return _ciFirstName; }
            set { _ciFirstName = value; }
        }
        public string CliMail
        {
            get { return _cliMail; }
            set { _cliMail = value; }
        }

        public string CliCompany
        {
            get { return _cliCompany; }
            set { _cliCompany = value; }
        }


        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public List<ClientEndorseDev> ClientEndorseDev { get { return LoadEndorseDev(); } }

     
        #endregion


        #region Function
        private List<ClientEndorseDev> LoadEndorseDev()
        {
            throw new NotImplementedException();
        }
        #region Static

        /// <summary>
        /// Peremet de récupérer la totalité des Clients
        /// </summary>
        /// <returns>Une liste de clients</returns>
        public static List<Client> ChargerTousLesClient()
        {
            List<Dictionary<string, object>> lstCli =
                GestionConnexion.Instance.getData("select * from Client");
            List<Client> retour = new List<Client>();
            foreach (Dictionary<string, object> item in lstCli)
            {
                Client cli = Associe(item);
                retour.Add(cli);
            }
            return retour;
        }
        /// <summary>
        /// Permet de récupérer 1 client à partir de son ID
        /// </summary>
        /// <param name="idD">Id du client a charger</param>
        /// <returns>Le Client</returns>
        public static Client ChargerUnClient(int idD)
        {
            List<Dictionary<string, object>> UnDev =
            GestionConnexion.Instance.getData("select * from Client where idClient=" + idD);
            Client dev = Associe(UnDev[0]);
            return dev;
        }
        /// <summary>
        /// Permet de vérifier si le login/pass est ok
        /// </summary>
        /// <param name="login">le login, ha bon?</param>
        /// <param name="password">le password (sans blague)</param>
        /// <returns>Soit un Client vide soit le client corrspondant</returns>
        public static Client VerfiClient(string login, string password)
        {
            /*!!!!!! Dans la réalité, il faudrait travailler avec une requ^te parametrée pour éviter les injections sql!!!!*/

            string pass = Tools.CalculateSha1(password, Encoding.UTF8);
            List<Dictionary<string, object>> UnDev =
                GestionConnexion.Instance.getData("select * from Client where CliLogin='" + login + "' And CliPassword= '" + pass +"'");
            if (UnDev.Count > 0)
            {
                Client dev = Associe(UnDev[0]);
                return dev;
            }
            else
                return null;
        }
        /// <summary>
        /// Permet d'associer les champs du dictionnaire aux propriétés correspondantes
        /// </summary>
        /// <param name="item">Un dictionnaire (nom col, valeur)</param>
        /// <returns>un client rempli</returns>
        private static Client Associe(Dictionary<string, object> item)
        {
            Client dev = new Client()
            {
                IdClient = (int)item["idClient"],
                CliName = item["CliName"].ToString() + ' ' + item["CliFirstName"],
                CliMail = item["CliMail"].ToString(),
                CliCompany = item["CliCompany"].ToString(),
                Login = item["CliLogin"].ToString()
            };
            return dev;
        }
     

        #endregion
        
        #endregion
    }
}
