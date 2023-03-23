using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SmartCanteenSI.Controllers
{
    public class UserController : Controller
    {
        SmartCanteenContext context=new SmartCanteenContext();
        public ActionResult EditProfile()
        {
            if (Session["UserID"] != null)
            {
                long userID =long.Parse(Session["UserID"].ToString());
                User check = context.Users.First(u => u.UserID == userID);

                return View(check);
            }
            else
            {
                return RedirectToAction("LoginPage","Login");
            }
            
        }
        public JsonResult Edit(User user)
        {
            string result = "Fail";
            User editUser=context.Users.SingleOrDefault(u => u.UserID == user.UserID);
            if (ModelState.IsValid)
            {
                if (editUser != null)
                {
                    try
                    {
                        result = "Success";
                        Session["Image"] = user.Image;
                        Session["UserName"] = user.UserName;
                        editUser.FullName = user.FullName;
                        editUser.PhoneNumber = user.PhoneNumber;
                        editUser.Email = user.Email;
                        editUser.UserName = user.UserName;
                        editUser.Image = user.Image;
                        editUser.BirthDay =user.BirthDay;
                        context.Users.AddOrUpdate(editUser);
                        context.SaveChanges();
                    }
                    catch
                    {
                        result = "Error";
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet); 
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("/images/Avatar/UserAvatar" + file.FileName));
            return "/images/Avatar/UserAvatar" + file.FileName;
        }
    }
}