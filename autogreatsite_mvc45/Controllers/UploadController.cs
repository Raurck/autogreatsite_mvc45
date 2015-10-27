using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raurck.Models;

namespace Raurck.Controllers
{
    public partial class UploadController : Controller
    {

        //public static List<DocumentModel> Docs = new List<DocumentModel>();
        private static UploadedDocuments updoc = new UploadedDocuments();

        public ActionResult Index()
        {
            return View("_IndexMulti");
        }

        public ActionResult GetFileAsync(int id)
        {
            // get your file from the database async...
            return View("_IndexMulti");
        }

        public FileUploadJsonResult AjaxUpload(HttpPostedFileBase file)
        {
            if ((file != null) && (!string.IsNullOrEmpty(file.FileName)))
            {
                //save data
                updoc.Add(file);
            }
            if (file == null)
            {
                //return PartialView("_UploadForm", updoc);
                  return new FileUploadJsonResult { Data = new { message = "FileUploadJsonResultMessage" } };
            }
            //return PartialView("_UploadForm", updoc);
            return new FileUploadJsonResult { Data = new { message = System.IO.Path.GetFileName(file.FileName) + "FileUploadJsonResultMessageSuccess" } };

        }

        public JsonResult AjaxUploadMulti(List<HttpPostedFileBase> filesToUpload)
        {
            var resultFiles = "";
            if ((filesToUpload != null))
            {
                foreach (var f in filesToUpload) { //save data
                    if (!string.IsNullOrEmpty(f.FileName))
                    {
                        updoc.Add(f);
                        resultFiles = resultFiles + f.FileName;
                    }
                }
            }
            if (filesToUpload == null)
            {
                //return PartialView("_UploadForm", updoc);
                return new JsonResult {  Data = ""  };
            }
            //return PartialView("_UploadForm", updoc);
            return new JsonResult { Data =  resultFiles  };

        }


        public PartialViewResult UploadForm()
        {
             return PartialView("_UploadForm",updoc);
        }

    }
}

