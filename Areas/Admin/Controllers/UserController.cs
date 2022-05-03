using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Areas.Admin.Attributes;
using BTCK_PhanTienDo.Models;
using X.PagedList;
using BC = BCrypt.Net.BCrypt;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class UserController : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult Index(int? page)
        {
            //lay trang hien tai
            //page ?? 1
            //neu page khac null thi _CurrentPage = page
            //neu page =  null thi _CurrentPage = 1
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 4;
            //lay tat ca cac ban ghi trong bang Users
            //(anhxa=>anhxa.ID) -> sap xep cot ID giam dan (tu gia tri cao nhat den thap nhat)
            List<UsersRecord> listRecord = db.Users.OrderByDescending(anhxa => anhxa.ID).ToList();
            //truyen gia tri ra view co phan trang
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        //mac dinh trang thai cua trang la GET -> khong can dinh nghia trang thai trang
        //bang lenh [HttpGet]
        public IActionResult Update(int? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            int _id = id ?? 0;
            //lay mot ban ghi
            UsersRecord record = db.Users.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
            //goi view, truyen du lieu ra view
            return View("CreateUpdate", record);
        }
        //do khi an nut submit thi trang o trang thai POST-> phai khai bao [HttpPost]
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            int _id = id ?? 0;
            //su dung Request.Form["email"] de lay gia tri cua the form
            //Trim(): cat khoang trang ben trai, ben phai cua gia tri
            string _UserName = fc["UserName"].ToString().Trim();
            //co the dung doi tuong fc de lay gia tri cua the form
            string _Password = fc["password"].ToString().Trim();
            //lay mot ban ghi tuong ung voi id
            UsersRecord record = db.Users.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
            record.UserName = _UserName;
            //neu password khong rong thi update password
            /*
             !String.IsNullOrEmpty(_Password) <=> String.IsNullOrEmpty(_Password) == false
             String.IsNullOrEmpty(_Password) <=> String.IsNullOrEmpty(_Password) == true
             */
            if (!String.IsNullOrEmpty(_Password))
            {
                //ma hoa password
                _Password = BC.HashPassword(_Password);
                record.Password = _Password;
            }
            //cap nhat lai table
            db.SaveChanges();
            //di chuyen den url
            return Redirect("/Admin/User");
        }
        //Create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        //khi an nut submit -> trang thai trang se la POST
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _UserName = fc["UserName"].ToString().Trim();
            string _Email = fc["email"].ToString().Trim();
            string _Password = fc["password"].ToString().Trim();
            //ma hoa password
            _Password = BC.HashPassword(_Password);
            //---
            UsersRecord record = new UsersRecord();
            record.UserName = _UserName;
            record.Email = _Email;
            record.Password = _Password;

            //them ban ghi vao table
            db.Users.Add(record);
            //cap nhat lai cac ban ghi
            db.SaveChanges();

            //toa ban ghi role
            RoleRecord role = new RoleRecord();
            role.UserId = record.ID;
            db.Role.Add(role);
            db.SaveChanges();
            //---
            return Redirect("/Admin/User");
        }
        //xoa ban ghi
        public IActionResult Delete(int? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            int _id = id ?? 0;
            //lay mot ban ghi
            UsersRecord record = db.Users.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
            //xoa ban ghi khoi csdl
            db.Users.Remove(record);
            RoleRecord role = db.Role.Where(tbl => tbl.UserId == _id).FirstOrDefault();
            db.Role.Remove(role);

            //cap nhat lai cac ban ghi
            db.SaveChanges();
            //goi view, truyen du lieu ra view
            return Redirect("/Admin/User");
        }
    }
}
