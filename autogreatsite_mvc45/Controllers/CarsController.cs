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
    public class CarsController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var cars = db.Cars.Include(c => c.CarBody).Include(c => c.CarBrand).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission);
            return View(await cars.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = await db.Cars.Include(c => c.CarBody).Include(c => c.CarBrand).Include(c => c.CarDrive).Include(c => c.CarEngine).Include(c => c.CarRudder).Include(c => c.CarTransmission).Where(c => c.CarId == id).FirstAsync();

            if (car == null)
            {
                return HttpNotFound();
            }

            
            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name");
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
        
        public async Task<ActionResult> Create([Bind(Include = "CarPhoto,CarId,Model,BrandId,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car,
            List<HttpPostedFileBase> filesToUpload)
        {
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
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);

            return View(car);
        }

        // GET: Cars/Edit/5
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
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.BrandId);
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
        public async Task<ActionResult> Edit([Bind(Include = "CarId,Model,BrandId,DistanceTraveled,Price,IssueYar,BodyId,TransmissionId,RudderId,OwnerCount,DriveId,EngineId,CarColor,Description")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BodyId = new SelectList(db.Bodys, "BodyID", "Name", car.BodyId);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", car.BrandId);
            ViewBag.DriveId = new SelectList(db.Drives, "DriveID", "Name", car.DriveId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineId", car.EngineId);
            ViewBag.RudderId = new SelectList(db.Rudders, "RudderID", "Name", car.RudderId);
            ViewBag.TransmissionId = new SelectList(db.Transmissions, "TransmissionID", "Name", car.TransmissionId);
            return View(car);
        }

        // GET: Cars/Delete/5
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
