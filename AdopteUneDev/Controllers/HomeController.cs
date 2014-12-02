
using AdopteUneDev.Models;
using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Session["ControllerContext"] = this.ControllerContext;
            HomeModel HM = new HomeModel()
            {
                lstCateg = Categories.ChargerToutesLesCategories(),
                lstLangs = ITLang.ChargerToutesLesITLang(),
                lstDev = Developer.ChargerTousLesDev()
            };

            return View(HM);
        }
	}
}