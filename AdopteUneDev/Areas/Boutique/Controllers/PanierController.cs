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
        [HttpGet]
        public ActionResult AddToBasket(int id,int qte,bool op)
        {
            if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).Count() > 0)
            {
                if (op)
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte += qte;
                }
                else
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte -= qte;
                }

                if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte < 1) SessionTools.Panier.Lignes.Remove(SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault());
            }
            return View("Panier", SessionTools.Panier);
        }

       [HttpPost]
        public ActionResult AddToBasket(int qte, int id)
        {
            Developer dev = Developer.ChargerUnDev(id);

            if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).Count() > 0)
           {
               SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte += qte;  
           }
           else{
            Ligne l = new Ligne() { ZeDave = Developer.ChargerUnDev(id), Qte = qte };
            SessionTools.Panier.Lignes.Add(l);
           }

            return View("Panier", SessionTools.Panier);
        }
	}
}