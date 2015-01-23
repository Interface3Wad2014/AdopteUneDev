using AdopteUneDev.Areas.Boutique.Models;
using AdopteUneDev.WADAL;
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

        public static bool isLogged
        {
            get
            {
                if (HttpContext.
                   Current.Session["isLogged"] == null)
                {
                    HttpContext.
                        Current.Session["isLogged"] = false;
                }

                return (bool)HttpContext.
                    Current.Session["isLogged"];
            }
            set
            {
                HttpContext.
                    Current.Session["isLogged"] = value;
            }
        }

        public static Client LogCli
        {
            get
            {
                if (HttpContext.
                    Current.Session["LogCli"] == null)
                {
                    HttpContext.
                        Current.Session["LogCli"] = new Client();
                }

                return (Client)HttpContext.
                    Current.Session["LogCli"];
            }
            set
            {
                HttpContext.
                        Current.Session["LogCli"] = value;
            }
        }
    }
}