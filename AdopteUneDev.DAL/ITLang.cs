using System;
using System.Collections.Generic;
namespace AdopteUneDev.DAL
{

    public partial class ITLang : IEntity<Dictionary<string,int>,int>
    {
    
        public int idIT { get; set; }
        public string ITLabel { get; set; }
        public int idCategory { get; set; }

        public List<DevLang> DevLang { get { return DataContext.LoadMany<DevLang, Dictionary<string, int>,int>(Key); } }
        public List<Categories> Categories { get { return DataContext.LoadMany<Categories, Dictionary<string, int>,int>(Key); } }


        public Dictionary<string, int> Key
        {
            get
            {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idIT", idIT);
                return ret;
            }
        }
    }
}
