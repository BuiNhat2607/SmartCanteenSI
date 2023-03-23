using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCanteenSI.Controllers
{
    public class ListDishController : Controller
    {
        SmartCanteenContext context =new SmartCanteenContext();
        // GET: ListDish
        public ActionResult ViewDishes()
        {
            List<Dish> dishList = context.Dishes.ToList();
            //var dishList = from dd in context.Dishes select dd;
            return View(dishList);
        }
    }
}