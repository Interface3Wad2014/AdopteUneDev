using AdopteUneDev.Models;
using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Controllers
{
    public class DevController : Controller
    {
        //
        // GET: /Dev/
        public ActionResult Details(int id)
        {
            Session["CurrentController"] = this;
            DetailsModel Current = new DetailsModel()
            {
                lstCateg = Categories.ChargerToutesLesCategories(),
                lstLangs = ITLang.ChargerToutesLesITLang(),
                lstDev = Developer.ChargerTousLesDev(),
                CurrentDev= Developer.ChargerUnDev(id)
            };

            return View(Current);
        }
	}
}