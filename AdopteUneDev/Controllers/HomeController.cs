using AdopteUneDev.DAL;
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
            
            List<Developer> ldev = DataContext.Developers;
            List<ClientEndorseDev> lendorse = ldev[0].ClientEndorseDev;
            return View();
        }
	}
}