using RestSharp;
using sauemk.web.Models;
using sauemk.web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sauemk.web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Control()
        {
            RestService service = new RestService();
            var sa = Request.Headers["Authorization"];
            var result = service.Get<Object>("admin/get", sa);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Liste()
        {
            return View();
        }
        public ActionResult EtkinlikEkle()
        {
            EtkinlikModel etkinlik = new EtkinlikModel();
            return View(etkinlik);
        }

        public ActionResult SaveUploadedFile(EtkinlikModel etkinlik)
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            var path = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Afis", Server.MapPath(@"\")));

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                RestService service = new RestService();
                RestRequest request = new RestRequest("api/Etkinliks", Method.POST);
                var token = Request.Headers["Authorization"];
                request.AddParameter("Adi", etkinlik.EtkinlikAdi);
                request.AddParameter("Tarihi", etkinlik.EtkinlikTarihi.ToShortDateString());
                request.AddParameter("AcilisTarihi", etkinlik.AcilisTarihi);
                request.AddParameter("KapanisTarihi", etkinlik.KapanisTarihi);
                request.AddParameter("Aciklama", etkinlik.Aciklama);
                request.AddParameter("FotoName", fName);

                var result = service.Execute<Object>(request,token);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }

    }
}