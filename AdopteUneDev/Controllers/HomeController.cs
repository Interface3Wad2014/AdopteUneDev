
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
            List<Categories> lesCategories = Categories.ChargerToutesLesCategories();

            return View(lesCategories);
        }
	}
}