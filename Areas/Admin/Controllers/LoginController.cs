
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
using System.Net.Mail;
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

        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Index(string EmailId)
        //{
        //    /*Create instance of entity model*/
            
        //    /*Getting data from database for email validation*/
        //    var _objuserdetail = (from data in db.Users
        //                          where data.Email == EmailId
        //                          select data);
        //    if (_objuserdetail.Count() > 0)
        //    {
        //        string status = SendPassword(_objuserdetail., _objuserdetail.Email, _objuserdetail.Name);
        //        ViewBag.Message = 1;
        //    }
        //    else
        //    {
        //        ViewBag.Message = 0;
        //    }
        //    return View();
        //}
        //public string SendPassword(string password, string emailId, string name)
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(emailId);
        //        mail.From = new MailAddress("youremail @gmail.com");
        //        mail.Subject = "Your password for account " + emailId;
        //        string userMessage = "";

        //        userMessage = userMessage + "<br/><b>Login Id:</b> " + emailId;
        //        userMessage = userMessage + "<br/><b>Passsword: </b>" + password;

        //        string Body = "Dear " + name + ", <br/><br/>Login detail for your account is a follows:<br/></br> " + userMessage + "<br/><br/>Thanks";
        //        mail.Body = Body;
        //        mail.IsBodyHtml = true;

        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com"; //SMTP Server Address of gmail
        //        smtp.Port = 587;
        //        smtp.Credentials = new System.Net.NetworkCredential("youremail@gmail.com", "password");
        //        // Smtp Email ID and Password For authentication
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        return "Please check your email for account login detail.";
        //    }
        //    catch
        //    {
        //        return "Error............";
        //    }
        //}
    }

   
}
