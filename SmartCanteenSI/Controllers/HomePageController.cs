using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCanteenSI.Controllers
{
    public class HomePageController : Controller    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}