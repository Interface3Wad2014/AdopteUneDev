using AdopteUneDev.Models;
using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Areas.Member.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Member/Login/
        public ActionResult Index(string backUrl="")
        {
            ViewBag.backUrl = backUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtLog, string txtPass, string backUrl)
        {
            Client cli = Client.VerfiClient(txtLog, txtPass);
            if (cli!=null)
            {
                SessionTools.isLogged = true;
                SessionTools.LogCli = cli;
                if (backUrl != "")
                {
                    return Redirect(backUrl);
                }
                else
                {
                    return RedirectToRoute(new { area = "", controller = "Home", action = "index" });
                }
            }
            else
            {
                ViewBag.backUrl = backUrl;
                return View("Index");
            }
        }
	}
}