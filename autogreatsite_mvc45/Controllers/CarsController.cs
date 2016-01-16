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
using System.Drawing;
using System.IO;

namespace autogreatsite_mvc45.Controllers
{
    [RoutePrefix("Cars")]
    public class CarsController : Controller
    {
        private CarContext db = new CarContext();
        private string UploadDir= "~/Content/Photo"; //must be in application settingns... but...
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

        [Route("NewestCars")]
        public async Task<ActionResult> NewestCars()
        {
            //var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand).OrderBy(c => c.CatalogDate).Take(3);
            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Include(c => c.CarModel).Include(c => c.CarModel.Brand).OrderByDescending(c=>c.CatalogDate).Take(10);
            return PartialView("_NewestCars", await cars.ToListAsync());
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

        /*
        // POST: Cars/FileUpload
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("FileUpload")]
        public void FileUpload()
        {
            HttpContext.Response.ContentType = "text/plain";

            string str_image = "";

            foreach (string s in HttpContext.Request.Files)
            {
                HttpPostedFileBase file = HttpContext.Request.Files[s];
                //  int fileSizeInBytes = file.ContentLength;
                string fileName = file.FileName;
                string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    str_image = Guid.NewGuid().ToString() + Path.GetExtension(fileName); 
                    string pathToSave_100 = Path.Combine(Server.MapPath("~/Content/Photo") , str_image);
                    file.SaveAs(pathToSave_100);
                }
            }
            HttpContext.Response.Write(str_image);
        }
        */
        // GET: Cars/Create
        [Authorize(Roles ="Administrator")]
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
        [Authorize(Roles = "Administrator")]
        [Route("Create")]
        public async Task<ActionResult> Create([Bind(Include = "CarPhoto,CarId,Model,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car,
            string ModelName, int BrandId, string[] name)
        {
            int modelId = -1;
            if (db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId == BrandId).Count() > 0)
            {
                modelId = db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId == BrandId).FirstOrDefault().ModelId;
            }
            else
            {
                db.CarModels.Add(new Model { ModelName = ModelName, BrandId = BrandId });
                db.SaveChanges();
                modelId = db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId == BrandId).FirstOrDefault().ModelId;
            }
            car.ModelId = modelId;
            if (ModelState.IsValid)
            {
                car.CatalogDate = DateTime.Now;
                db.Cars.Add(car);
                HttpCookie primaryPhoto = Request.Cookies["primaryPhoto"];
                string mainPhoto = "";
                if ((primaryPhoto != null) && (primaryPhoto.Value != null))
                {
                    mainPhoto = primaryPhoto.Value;
                }

                if (name != null)
                {
                    for(var i=0;i<name.Length;i++)
                    {

                            var oldName = (Server.MapPath(Path.Combine(UploadDir,"tmp", name[i])));
                            var tmbName = (Server.MapPath(Path.Combine(UploadDir, "tmp", "tmb", name[i])));
                            var baseName = Guid.NewGuid().ToString() + Path.GetExtension(name[i]);
                        
                        bool mf=false;
                        if (mainPhoto != null)
                        {
                            mf = (mainPhoto == name[i]);
                        }
                        car.CarPhoto.Add(new Photo { FileName = baseName, IsMain= mf });
                            System.IO.File.Move(oldName, Server.MapPath(Path.Combine(UploadDir, baseName)));
                            System.IO.File.Move(tmbName, Server.MapPath(Path.Combine(UploadDir, "tmb", baseName)));
                           // fl.SaveAs(Server.MapPath(System.IO.Path.Combine("~/Content/Photo", baseName)));
                           // Scale(Server.MapPath(System.IO.Path.Combine("~/Content/Photo", baseName)), 150);
                    }

                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name", car.BodyId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);

            return View(car);
        }

        // GET: Cars/Edit/5
        [Route("Edit/{id:int}")]
        [Authorize(Roles = "Administrator")]
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
            ViewBag.Id = id;
             ViewBag.ModelName = car.CarModel.ModelName;
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
        [Authorize(Roles = "Administrator")]
        [Route("Edit/{id:int}")]
        public async Task<ActionResult> Edit([Bind(Include = "CarPhoto,CarId,Model,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car,
            List<HttpPostedFileBase> filesToUpload, string ModelName, int BrandId, int? id)
        {
            int modelId = -1;
            if (db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId == BrandId ).Count() > 0)
            {
                modelId = db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId==BrandId).FirstOrDefault().ModelId;
            }
            else
            {
                db.CarModels.Add(new Model { ModelName = ModelName, BrandId = BrandId });
                db.SaveChanges();
                modelId = db.CarModels.Where(c => c.ModelName == ModelName && c.BrandId == BrandId).FirstOrDefault().ModelId;
            }
            car.ModelId = modelId;
            car.CarId = (int)id;
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = id;
            ViewBag.ModelName = car.CarModel.ModelName;
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
