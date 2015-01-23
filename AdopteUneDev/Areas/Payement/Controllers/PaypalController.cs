using AdopteUneDev.Areas.Payement.Models;
using AdopteUneDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Areas.Payement.Controllers
{
    public class PayPalController : Controller
    {
        public ActionResult RedirectFromPaypal()
        {
            return View();
        }
        public ActionResult CancelFromPaypal()
        {
            return View();
        }
        public ActionResult NotifyFromPaypal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateCommand(string product, string totalPrice)
        {
            if(SessionTools.LogCli.IdClient<1)
            {
                return RedirectToAction("Index", "Login", new { area = "Member", backUrl = "~/Boutique/Panier/Index" });
            }
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);
            paypal.item_name = product;
            paypal.amount = totalPrice;
            return View(paypal);
        }
    }
}