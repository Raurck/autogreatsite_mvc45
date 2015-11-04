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
using System.Text;

namespace autogreatsite_mvc45.Controllers
{
    [RoutePrefix("finder")]
    public class FinderController : Controller
    {
        private CarContext db = new CarContext();
        
        //private Finder f;
        // GET: Finder
        [Route("")]
        public async Task<ActionResult> Index()
        {
            var f = TempData["finder"] as Finder ?? new Finder(db);
            ViewBag.Brands = new SelectList(Finder.CarBrands.OrderBy(c => c.BrandId), "BrandId", "BrandName");
            ViewBag.Models = new SelectList(Finder.CarModels.OrderBy(c => c.ModelId), "ModelId", "ModelName");
            if (Request.Path.ToLower().Contains ("/finder") )
            {
                return View(f);
            }
            return PartialView(f); 
        }

        [Route("longview")]
        public async Task<ActionResult> longview()
        {
            if (Request.Path.ToLower().Contains("/finder"))
            {
                return new EmptyResult();
            }

            var f = TempData["finder"] as Finder ?? new Finder(db);
            ViewBag.Brands      = new SelectList(Finder.CarBrands.OrderBy(c => c.BrandId), "BrandId", "BrandName");
            ViewBag.Models      = new SelectList(Finder.CarModels.OrderBy(c => c.ModelId), "ModelId", "ModelName");
            ViewBag.Bodys        = new SelectList(Finder.CarBodys.OrderBy(c => c.BodyID), "BodyID", "Name");
            ViewBag.Rudders      = new SelectList(Finder.CarRudders.OrderBy(c => c.RudderID), "RudderID", "Name");
            ViewBag.Drives       = new SelectList(Finder.CarDrives.OrderBy(c => c.DriveID), "DriveID", "Name");
            ViewBag.Transmissons = new SelectList(Finder.CarTranssmisisons.OrderBy(c => c.TransmissionID), "TransmissionID", "Name");

            return PartialView("_longview", f);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> SearchResult(FormCollection form ,Finder f)
        {
            //if(Request.Headers.HasKeys(""))
            TempData["finder"] = f;

            //CarsController car = new CarsController();
            //return await car.Index(f);
            //return RedirectToAction("", "Cars", new Dictionary<string, object> { { "brand", f.f_brandId } });
            return RedirectToAction(f.ToSearchString(), "Cars");
            // return RedirectToRoute( "Cars/"+f.ToSearchString());

        }


        [HttpPost]
        [Route("RenewModels/{Brands:int}")]
        public async Task<ActionResult> RenewModels(int Brands)
        {
            var res = new JsonResult();
            res.ContentEncoding = Encoding.UTF8;
            res.ContentType = "text/plain";
            res.Data = Finder.getFiltredModelDropDownList(Brands);
            return res;
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
