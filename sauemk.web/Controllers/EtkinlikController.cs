using Newtonsoft.Json.Linq;
using RestSharp;
using sauemk.web.Core;
using sauemk.web.Models;
using sauemk.web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sauemk.web.Controllers
{
    public class EtkinlikController : Controller
    {
        // GET: Etkinlik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EtkinlikPage()
        {
            return View();
        }

        public JsonResult getEtkinlik()
        {
            RestService service = new RestService();
            var token = Request.Headers["Authorization"];
            var gecmis = service.Get<Object>("api/GecmisEtkinlik", token);
            var gelecek = service.Get<Object>("api/GelecekEtkinlik", token);
            var buHafta = service.Get<Object>("api/HaftaEtkinlik", token);
            return Json(new {
                gecmis,
                buHafta,
                gelecek
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Etkinlik(int id)
        {
            RestService service = new RestService();
            var request = new RestRequest("api/Etkinliks",Method.GET);
            request.AddParameter("id", id);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EtkinlikKayit(EtkinlikKayitModel kayitData)
        {
            Response response = new Response();
            if (kayitData.userName == null)
            {
                return Json(response.AuthorizeError());
            }
            RestService service = new RestService();
            var request = new RestRequest("api/EtkinlikUsers", Method.POST);
            request.AddParameter("UserId",kayitData.userName);
            request.AddParameter("EtkinlikId", kayitData.etkinlikId);
            request.AddParameter("CheckIn", false);
            request.AddParameter("CheckOut", false);
            request.AddParameter("CekilisKabul", false);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}