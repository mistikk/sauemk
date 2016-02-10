using RestSharp;
using sauemk.web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sauemk.web.Services;
using sauemk.web.Models;
using Newtonsoft.Json.Linq;

namespace sauemk.web.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {

            //var sa = service.Get<JsonArray>("api/values");


            return View();
        }

        //[RESTAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public int Numbers()
        {
            int sa = 12345;

            return sa;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}