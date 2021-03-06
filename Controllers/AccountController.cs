//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BTCK_PhanTienDo.Models;
////doi tg ma hoa password
//using System.Security.Cryptography;
//using System.Text;
//// sd doi tg session
//using Microsoft.AspNetCore.Http;
//namespace BTCK_PhanTienDo.Controllers
//{
//    public class AccountController : Controller
//    {
//        public MyDbContext db = new MyDbContext();

//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost, ValidateAntiForgeryToken]
//        public IActionResult RegisterPost()
//        {
//            string _Name = Request.Form["name"];
//            string _Email = Request.Form["email"];
//            string _Address = Request.Form["address"];
//            string _Phone = Request.Form["phone"];
//            string _Password = Request.Form["password"];
//            //ma hoa password
//            _Password = getHash(_Password);
//            //---
//            //kiem tra trong table Customers xem email da ton tai chua, neu chua ton tai thi insert
//            var check = db.Customers.Where(tbl => tbl.Email == _Email).FirstOrDefault();
//            if (check == null)
//            {
//                //return Content("ok");
//                //insert ban ghi
//                var record = new CustomersRecord();
//                record.Name = _Name;
//                record.Address = _Address;
//                record.Phone = _Phone;
//                record.Email = _Email;
//                record.Password = _Password;
//                //---
//                db.Customers.Add(record);
//                db.SaveChanges();
//            }
//            else
//            {
//                return Redirect("/Account/Register?mode=exists");
//            }
//            return Redirect("/Account/Register?mode=success");
//            //---
//        }
//        // ham ma hoa pw
//        public string getHash(string text)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
//                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
//            }
//        }
//        // login 
//        public IActionResult Login()
//        {
//            return View();
//        }
//        [HttpPost,ValidateAntiForgeryToken]
//        public IActionResult LoginPost()
//        {
//            string _Email = Request.Form["email"];
//            string _Password = Request.Form["password"];
//            _Password = getHash(_Password);
//            // ktra login 
//            var record = db.Customers.Where(tbl => tbl.Email == _Email && tbl.Password==_Password).FirstOrDefault();
//            if (record != null)
//            {
//                //return Content("ok");

//                // gan bien ss
//                HttpContext.Session.SetString("email", _Email);
//                HttpContext.Session.SetString("customer_id", record.ID.ToString());
//                return Redirect("/Home");
//            }
//            else return Redirect("/Account/Login?mode=invalid");
//        } 
//        public IActionResult Logout()
//        {
//            HttpContext.Session.Remove("email");
//            return Redirect("/Home");
//        }
//    }

//}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Models;
//đối tượng mã hóa password
using System.Security.Cryptography;
using System.Text;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Http;

namespace BTCK_PhanTienDo.Controllers
{
    public class AccountController : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RegisterPost()
        {
            string _Name = Request.Form["name"];
            string _Email = Request.Form["email"];
            string _Address = Request.Form["address"];
            string _Phone = Request.Form["phone"];
            string _Password = Request.Form["password"];
            _Password = GetHash(_Password);
            var check = db.Customers.Where(c => c.Email == _Email).FirstOrDefault();
            if (check == null)
            {
                var record = new CustomersRecord();
                record.Name = _Name;
                record.Email = _Email;
                record.Address = _Address;
                record.Phone = _Phone;
                record.Password = _Password;
                db.Customers.Add(record);
                db.SaveChanges();
            }
            else
            {
                return Redirect("/Account/Register?mode=exists");
            }
            return Redirect("/Account/Register?mode=success");
        }
        public string GetHash(string text)
        {
            //cơ chế băm
            using (var sha256 = SHA256.Create())
            {
                //hàm băm sẽ luôn băm thành 265 bit
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        //login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult LoginPost()
        {
            string _Email = Request.Form["email"];
            string _Password = Request.Form["password"];
            //mã hóa
            _Password = GetHash(_Password);
            var record = db.Customers.Where(c => c.Email == _Email && c.Password == _Password).FirstOrDefault();
            if (record != null)
            {
                HttpContext.Session.SetString("email", _Email);
                HttpContext.Session.SetString("customer_id", record.ID.ToString());
                return Redirect("/Home");
            }
            else
                return Redirect("/Account/Login?mode=invalid");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return Redirect("/Home");
        }
    }
}


