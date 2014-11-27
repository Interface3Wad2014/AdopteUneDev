using System;
using System.Collections.Generic;
namespace AdopteUneDev.DAL
{


    public class Client :IEntity<Dictionary<string, int>,int>
    {
    
        public int idClient { get; set; }
        public string CliName { get; set; }
        public string CliFirstName { get; set; }
        public string CliMail { get; set; }
        public string CliCompany { get; set; }

        public List<ClientEndorseDev> ClientEndorseDev { get { return DataContext.LoadMany<ClientEndorseDev, Dictionary<string, int>,int>(Key); } }



       public  Dictionary<string, int> Key
        {
            get
            {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idClient", idClient);
                return ret;
            }
        }
    }
}
