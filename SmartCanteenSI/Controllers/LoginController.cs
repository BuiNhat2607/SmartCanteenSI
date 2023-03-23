using SmartCanteenSI.Models;
using SmartCanteenSI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace SmartCanteenSI.Controllers
{
    public class LoginController : Controller
    {
        SmartCanteenContext context = new SmartCanteenContext();
        public int OTP = 0;
        public ActionResult LoginPage()
        {
            return View();
        }
        public JsonResult Register(User account)
        {
            string result = "NotExist";
            string adminMail = "misteranonymous2711@gmail.com";
            User checkmail = context.Users.Where(x => x.Email == account.Email).FirstOrDefault();
            if (checkmail == null && account.Email != adminMail)
            {
                account.Role = "User";
                account.IsValid = false;
                account.PassWord = BCrypt.Net.BCrypt.HashPassword(account.PassWord);
                account.Image = "/images/Avatar/pngtree-black-default-avatar-png-image_5407174.jpg";
                context.Users.Add(account);
                context.SaveChanges();
                BuildEmailTemplate((int)account.UserID);
            }
            else if (checkmail != null)
            {
                result = "Exist";
            }
            else if (account.Email == adminMail)
            {
                result = "notAdmin";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Validate(int regId)
        {
            ViewBag.regID = regId;
            return View();
        }
        public JsonResult RegisterValidate(int regId)
        {
            User Data = context.Users.Where(x => x.UserID == regId).FirstOrDefault();
            Data.IsValid = true;
            context.SaveChanges();
            var msg = "Email của bạn đã được xác thực!";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public void BuildEmailTemplate(int regID)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/EmailTemplate/") + "Template" + ".cshtml");
            var regInfo = context.Users.Where(x => x.UserID == regID).FirstOrDefault();
            var url = "https://localhost:44305/" + "Login/Validate?regId=" + regID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Tài khoản của bạn được tạo thành công!", body, regInfo.Email);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "witherdragonlair@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendMail(mail);
        }

        public static void SendMail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("witherdragonlair@gmail.com", "wsemqzzmqcuzxtjz");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult CheckAccount(User model)
        {
            string result = "Fail";
            var checkAccount = context.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            
            if (checkAccount != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(model.PassWord, checkAccount.PassWord);
                if (verified == true)
                {
                    if (checkAccount.Email == model.Email && checkAccount.IsValid == true)
                    {
                        Session["Account"] = checkAccount;
                        Session["UserID"] = checkAccount.UserID.ToString();
                        Session["UserName"] = checkAccount.UserName.ToString();
                        Session["Image"] = checkAccount.Image.ToString();
                        Session["Role"]=checkAccount.Role.ToString();
                        result = "Success";
                    }
                    var isValid = checkAccount.IsValid;
                    if (isValid == false)
                    {
                        result = "notValid";
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendOTP(User user)
        {

            bool Valid = false;
            User checkEmail = context.Users.SingleOrDefault(x => x.Email == user.Email);
            if (checkEmail != null)
            {
                if (checkEmail.IsValid == false)
                {
                    return Json(Valid, JsonRequestBehavior.AllowGet);
                }
                Valid = true;
                Random rand = new Random();
                OTP = rand.Next(100000, 1000000);
                Session["OTP"] = OTP.ToString();
                var fromAddress = new MailAddress("witherdragonlair@gmail.com");
                var toAddress = new MailAddress(user.Email);
                const string fromPass = "wsemqzzmqcuzxtjz";
                const string subject = "OTP code";
                string body = "Đây là mã xác thực của bạn:\nVui lòng không chia sẻ mã này cho bất kì ai khác:\n" + "\t" + OTP.ToString();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPass),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                })
                {
                    smtp.Send(message);
                }
            }

            return Json(Valid, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ResetPass(User user, FormCollection collection)
        {
            var otp = collection["OTP"];
            string kq = "NotValid";
            var checkMail = context.Users.SingleOrDefault(x => x.Email == user.Email);
            if (Session["OTP"] == null)
            {
                kq = "WrongOTP";
            }
            else if (checkMail != null && otp == Session["OTP"].ToString())
            {
                kq = "Valid";
                checkMail.PassWord = BCrypt.Net.BCrypt.HashPassword(user.PassWord);
                context.SaveChanges();
                Session.Clear();
                Session.Abandon();
            }
            else if (otp != Session["OTP"].ToString())
            {
                kq = "WrongOTP";
            }
            return Json(kq, JsonRequestBehavior.AllowGet);
        }

    }
}