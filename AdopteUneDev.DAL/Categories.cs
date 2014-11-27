
namespace AdopteUneDev.DAL
{
    using System;
    using System.Collections.Generic;

    public class Categories :IEntity<Dictionary<string, int>,int>
    {
    
        public int idCategory { get; set; }
        public string CategLabel { get; set; }

        public List<ITLang> ITLang { get { return DataContext.LoadMany<ITLang, Dictionary<string, int>,int>(Key); } }



        
       public Dictionary<string, int> Key
        {
            get {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idCategory", idCategory);
                return ret;
            }
        }
    }
}
