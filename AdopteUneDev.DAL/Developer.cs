using System;
using System.Collections.Generic;
namespace AdopteUneDev.DAL
{


    public class Developer : IEntity<Dictionary<string, int>,int>
    {       
        public int idDev { get; set; }
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        public DateTime DevBirthDate { get; set; }
        public string DevPicture { get; set; }
        public double DevHourCost { get; set; }
        public double DevDayCost { get; set; }
        public double DevMonthCost { get; set; }
        public string DevMail { get; set; }

        #region Navigation Properties
        public List<ClientEndorseDev> ClientEndorseDev {get { return DataContext.LoadMany<ClientEndorseDev, Dictionary<string, int>,int>(Key); } }
        public List<DevLang> DevLang { get { return DataContext.LoadMany<DevLang, Dictionary<string, int>,int>(Key); } } 
        #endregion


       public Dictionary<string, int> Key
        {
            get
            {
                Dictionary<string, int> ret = new Dictionary<string, int>();
                ret.Add("idCategory", idDev);
                return ret;
            }
        }
    }
}
