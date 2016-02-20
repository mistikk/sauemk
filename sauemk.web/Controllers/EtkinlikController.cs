using Newtonsoft.Json.Linq;
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

        public JsonResult getEtkinlik()
        {
            dynamic etkinlik = new Object();
            RestService service = new RestService();
            var token = Request.Headers["Authorization"];
            var gecmis = service.Get<Object>("api/GecmisEtkinlik", token);
            var gelecek = service.Get<Object>("api/GelecekEtkinlik", token);
            var buHafta = service.Get<Object>("api/HaftaEtkinlik", token);
            return etkinlik;
        }

    }
}