using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVC.Controllers
{

    public class HomeController : Controller
    {
        //Home/Index
        public ActionResult Index()
        {
            ViewBag.User = "Maria";
            return View();
        }

        public ActionResult About()
        {
                 return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}