using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autogreatsite_mvc45.Models;

namespace autogreatsite_mvc45.Controllers
{
    public class FinderController : Controller
    {
        private CarContext db = new CarContext();
        private Finder f;
        // GET: Finder
        public async Task<ActionResult> Index()
        {
            f = new Finder(db);
            ViewData["Brands"] = new SelectList(f.CarBrands, "BrandId", "BrandName");
            return  PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
