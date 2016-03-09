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

        [HttpGet]
        public ActionResult HizliKayit()
        {
            return View();
        }

        public ActionResult CheckIn()
        {
            return View();
        }

        public ActionResult Cekilis()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getCekilis()
        {
            RestService service = new RestService();
            var request = new RestRequest("api/Cekilis", Method.GET);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult KariyerSampiyonlariEkle(KariyerSampiyonlariKayit user)
        {
            RestService service = new RestService();
            var request = new RestRequest("api/KariyerSampiyonlariKayit", Method.POST);
            request.AddParameter("Email", user.Email);
            request.AddParameter("Name", user.Name);
            request.AddParameter("Surname", user.Surname);
            request.AddParameter("Phone", user.Phone);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
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
        public JsonResult EtkinlikCheckin(EtkinlikKayitModel kayitData)
        {
            Response response = new Response();
            if (kayitData.userName == null)
            {
                return Json(response.AuthorizeError());
            }
            RestService service = new RestService();
            var request = new RestRequest("api/PutEtkinlikUser", Method.POST);
            request.AddParameter("UserId", kayitData.userName);
            request.AddParameter("EtkinlikId", kayitData.etkinlikId);
            request.AddParameter("CheckIn", kayitData.checkin);
            request.AddParameter("CheckOut", false);
            request.AddParameter("CekilisKabul", false);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult HizliKaydet(HizliKayitModel kayitData)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return Json(response.ModelError());
            }
            
            RestService service = new RestService();
            var login = new RestRequest(Method.POST);
            login.Resource = "api/Account/Register";
            login.AddHeader("Content-Type", "application/json");
            login.AddParameter("grant_type", "password");
            login.AddParameter("Email", kayitData.Email);
            login.AddParameter("Name", kayitData.Name);
            login.AddParameter("Surname", kayitData.Surname);
            login.AddParameter("Phone", kayitData.Phone);

            var pass = System.Web.Security.Membership.GeneratePassword(6, 1);

            login.AddParameter("Password", pass);
            login.AddParameter("ConfirmPassword", pass);
            
            var loginresult = service.Execute<Object>(login);

            if (loginresult.error == true)
            {
                return Json(response.ModelError());
            }

            var request = new RestRequest("api/EtkinlikUsers", Method.POST);
            request.AddParameter("UserId", kayitData.Email);
            request.AddParameter("EtkinlikId", kayitData.EtkinlikId);
            request.AddParameter("CheckIn", true);
            request.AddParameter("CheckOut", false);
            request.AddParameter("CekilisKabul", true);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchUser(SearchUserModel user)
        {
            RestService service = new RestService();
            var request = new RestRequest("api/SearchUser", Method.POST);
            request.AddParameter("Name", user.Name);
            request.AddParameter("Surname", user.Surname);
            var token = Request.Headers["Authorization"];
            var result = service.Execute<Object>(request, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}