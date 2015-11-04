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
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;

namespace autogreatsite_mvc45.Controllers
{
    [RoutePrefix("Cars")]
    public class CarsController : Controller
    {
        private CarContext db = new CarContext();
        
        // GET: Cars
        [Route("{brand}")]
        public async Task<ActionResult> Index(string brand)
        {
            var f = TempData["finder"] as Finder ?? new Finder(db);
            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand).Where(c => c.CarModel.Brand.BrandName == brand);
            return View(await cars.ToListAsync());
        }

        [Route("{brand}/{model}")]
        public async Task<ActionResult> Index(string brand, string model)
        {
            var f = TempData["finder"] as Finder ?? new Finder(db);
            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand).Where(c => (c.CarModel.Brand.BrandName == brand)&&(c.CarModel.ModelName==model));
            return View(await cars.ToListAsync());
        }

        [Route("{brand}/{model}/years/{minYear:int}/{maxYear:int}/price/{minPrice:int}/{maxPrice:int}")]
        public async Task<ActionResult> Index(string brand, string model, int minYear, int maxYear, int minPrice, int maxPrice)
        {

            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand);
            if (model.ToLower() != "all")
            {
                cars = cars.Where(c =>c.CarModel.ModelName== model);
            }
            else if (brand.ToLower() != "all")
            {
                cars = cars.Where(c => c.CarModel.Brand.BrandName==brand);
            }
            cars = cars.Where(c => ((c.Price >= minPrice) && (c.Price <= maxPrice))).Where(c => ((c.IssueYar >= minYear) && (c.IssueYar <= maxYear)));
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CarsList", await cars.ToListAsync());
            }
            
            return View(await cars.ToListAsync());

        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand);
            return View(await cars.ToListAsync());
        }

        // GET: Cars/Details/5
        [Route("Details/{id:int}")]
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = await db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand).Where(c => c.CarId == id).FirstAsync();

            if (car == null)
            {
                return HttpNotFound();
            }

            
            return View(car);
        }

        // GET: Cars/Create
        //[Authorize(Roles ="Administrator")]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name");
            ViewBag.ModelName ="";
            //ViewBag.ModelId = new SelectList(db.CarModels, "ModelID", "ModelName");
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName");
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name");
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId");
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name");
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create([Bind(Include = "CarPhoto,CarId,Model,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car,
            List<HttpPostedFileBase> filesToUpload, string ModelName)
        {
            int modelId = -1;
            if (db.CarModels.Where(c => c.ModelName == ModelName).Count() > 0)
            {
                modelId = db.CarModels.Where(c => c.ModelName == ModelName).FirstOrDefault().ModelId;
            }
            else
            {
                db.CarModels.Add(new Model { ModelName = ModelName });
                db.SaveChanges();
                modelId = db.CarModels.Where(c => c.ModelName == ModelName).FirstOrDefault().ModelId;
            }
            car.ModelId = modelId;
            if (ModelState.IsValid)
            {

                db.Cars.Add(car);

                if (filesToUpload != null)
                {
                    foreach (var fl in filesToUpload)
                    {
                        if ((fl!=null) &&( fl.ContentType.StartsWith("image/") ))
                        {
                            
                            var baseName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fl.FileName); ;
                            car.CarPhoto.Add(new Photo { FileName = baseName });
                            fl.SaveAs(Server.MapPath(System.IO.Path.Combine("~/Content/Photo", baseName)));
                        }
                    }

                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name", car.BodyId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.CarModel.BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);

            return View(car);
        }

        // GET: Cars/Edit/5
        [Route("Edit/{id:int}")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name", car.BodyId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.CarModel.BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int}")]
        public async Task<ActionResult> Edit([Bind(Include = "CarId,Model,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name", car.BodyId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.CarModel.BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);
            return View(car);
        }

        // GET: Cars/Delete/5
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
