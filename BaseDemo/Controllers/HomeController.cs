using System;
using System.Web.Mvc;
using BaseDemo.Models;

namespace BaseDemo.Controllers {
    public class HomeController :Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            ViewBag.MyProperty = "My special property";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}