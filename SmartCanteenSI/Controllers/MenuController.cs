using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SmartCanteenSI.Controllers
{
    public class MenuController : Controller
    {
        SmartCanteenContext context=new SmartCanteenContext();
        // GET: Menu
        public ActionResult FoodMenu(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var allDishes = (from ss in context.Dishes select ss).OrderBy(m => m.DishID);
            int pageSize = 4;//mỗi trang 2 món
            int pageNum = page ?? 1;
            return View(allDishes.ToPagedList(pageNum, pageSize));
        }
    }
}