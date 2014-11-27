using System;
using System.Collections.Generic;
namespace AdopteUneDev.DAL
{


    public partial class DevLang : IEntity<Dictionary<string, int>,int>
    {
        public int idDev { get; set; }
        public int idIT { get; set; }
        public DateTime? Since { get; set; }


        public Developer Developer { get { return DataContext.LoadOne<Developer, int>(idDev); } }
        public ITLang ITLang { get { return DataContext.LoadOne<ITLang, int>(idIT); } }



        public Dictionary<string, int> Key
        {
            get {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idDev", idDev);
                ret.Add("idIT", idIT);
                return ret;
            }
        }
    }
}
