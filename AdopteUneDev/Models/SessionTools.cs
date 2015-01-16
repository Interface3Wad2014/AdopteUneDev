using AdopteUneDev.Areas.Boutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdopteUneDev.Models
{
    public static class SessionTools
    {
        public static Panier Panier
        {
            get
            {
                if (HttpContext.
                    Current.Session["Panier"] == null)
                {
                    HttpContext.
                        Current.Session["Panier"] = new Panier();
                }

                return (Panier)HttpContext.
                    Current.Session["Panier"];
            }
            set
            {
                HttpContext.
                    Current.Session["Panier"] = value;
            }
        }
    }
}