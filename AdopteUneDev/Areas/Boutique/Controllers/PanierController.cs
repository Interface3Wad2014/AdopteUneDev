using AdopteUneDev.Areas.Boutique.Models;
using AdopteUneDev.Models;
using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Areas.Boutique.Controllers
{
    public class PanierController : Controller
    {
       [HttpPost]
        public ActionResult AddToBasket(Developer dev, int qte)
        {
            Ligne l = new Ligne() { ZeDave = dev, Qte = qte };
            SessionTools.Panier.Add(l);

            return View();
        }
	}
}