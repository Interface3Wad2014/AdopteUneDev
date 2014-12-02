using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopteUneDev.Models
{
    public class HomeModel
    {
        public List<Categories> lstCateg
        {
            get;
            set;
        }

        public List<ITLang> lstLangs
        {
            get;
            set;
        }

        public List<Developer> lstDev
        {
            get;
            set;
        }
    }
}