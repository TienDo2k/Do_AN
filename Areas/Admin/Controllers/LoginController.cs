
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Models;
using BC = BCrypt.Net.BCrypt;



namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        MyDbContext db = new MyDbContext();
       
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(IFormCollection fc)
        {
           
            string _email = fc["email"];
            string _password = fc["password"];
            ViewBag.error = 0;
            UsersRecord record = db.Users.Where(tbl => tbl.Email == _email).FirstOrDefault();
            
            if (record != null)
            {
                if (BC.Verify(_password, record.Password))
                {
                    //khởi tạo biến session
                    HttpContext.Session.SetString("email", _email);
                    HttpContext.Session.SetString("UserID", record.ID.ToString());
                    
                    return Redirect("/Admin/Home");
                }
                else
                {
                    ViewBag.error = 1;
                   
                    //return View(fc);
                }
            }
            else
            {
                ViewBag.error = 2;
                
                //return View(fc);
            }
            if(ViewBag.error == 1)
            {
                ModelState.AddModelError("", "Sai Mật Khẩu");
            }
            else if(ViewBag.error == 2)
            {
                ModelState.AddModelError("", "Sai Email");
            }
            return View();
           // return Redirect("/Admin/Login/Login");

        }
        //đăng xuất
        public IActionResult Logout()
        {
            //hủy biến session
            HttpContext.Session.Remove("email");
            return Redirect("/Admin/Login/Login");
        }

        //Quên MK
       
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            string resetCode = Guid.NewGuid().ToString();
            var verifyUrl = "/Account/ResetPassword/" + resetCode;
            var link = HttpContext.Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            using (var context = new MyDbContext())
            {
                var getUser = (from s in context.Users where s.Email == EmailID select s).FirstOrDefault();
                if (getUser != null)
                {
                    getUser.ResetPasswordCode = resetCode;

                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 

                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();

                    var subject = "Password Reset Request";
                    var body = "Hi " + getUser.FirstName + ", <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +

                         " <br/><br/><a href='" + link + "'>" + link + "</a> <br/><br/>" +
                         "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";

                    SendEmail(getUser.Email, body, subject);

                    ViewBag.Message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    ViewBag.Message = "User doesn't exists.";
                    return View();
                }
            }

            return View();
        }

        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("youremail@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("youremail@gmail.com", "YourPassword");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }

    }

   
}
