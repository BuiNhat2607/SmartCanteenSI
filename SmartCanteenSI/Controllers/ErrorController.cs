using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCanteenSI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult OutOfStock()
        {
            return View();
        }
        public ActionResult OutOfStockOrder()
        {
            return View();
        }
    }
}