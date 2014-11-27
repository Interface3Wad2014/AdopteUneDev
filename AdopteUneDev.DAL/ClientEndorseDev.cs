using System;
using System.Collections.Generic;
namespace AdopteUneDev.DAL
{


    public partial class ClientEndorseDev : IEntity<Dictionary<string, int>,int>
    {
        public int idClient { get; set; }
        public int idDev { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EndorseNumber { get; set; }

        public Client Client { get { return DataContext.LoadOne<Client, int>(idClient); } }
        public Developer Developer { get { return DataContext.LoadOne<Developer, int>(idDev); } }





        public Dictionary<string, int> Key
        {
            get {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idClient", idClient);
                ret.Add("idDev", idDev);
                return ret;
            }
        }
    }
}
