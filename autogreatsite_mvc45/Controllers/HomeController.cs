using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using autogreatsite_mvc45.Models;

namespace autogreatsite_mvc45.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "";

            return View();
        }


        public ActionResult Sell()
        {
            ViewData["Message"] = "";

            return View();
        }

        public ActionResult Commision()
        {
            ViewData["Message"] = "";

            return View();
        }

        public ActionResult Buy()
        {
            ViewData["Message"] = "";

            return View();
        }

        public ActionResult Credit()
        {
            ViewData["Message"] = "";

            return View();
        }

        public ActionResult TradeIn()
        {
            ViewData["Message"] = "";

            return View();
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
