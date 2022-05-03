using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//su dung doi tuong sau de thao tac voi ham IFormCollection
using Microsoft.AspNetCore.Http;
//su dung cac class ben trong thu muc Models
using BTCK_PhanTienDo.Models;
using Microsoft.EntityFrameworkCore;
//doi tuong phan trang
using X.PagedList;
//de nhin thay file CheckLogin.cs trong thu muc Attributes thi phai using no
using BTCK_PhanTienDo.Areas.Admin.Attributes;
//doi tuong thao tac file
using System.IO;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    //Khai bao Route Admin de nhan dien tren url day la Area Admin
    [Area("Admin")]
    //Kiem tra login
    //[CheckLogin]
    public class NewsController : Controller
    {
        //khai bao bien toan cuc la bien de thao tac csdl
        public MyDbContext db = new MyDbContext();
        public IActionResult Index(int? page)
        {
            //lay trang hien tai
            //page ?? 1
            //neu page khac null thi _CurrentPage = page
            //neu page =  null thi _CurrentPage = 1
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //lay tat ca cac ban ghi trong bang Users
            //(anhxa=>anhxa.ID) -> sap xep cot ID giam dan (tu gia tri cao nhat den thap nhat)
            List<NewsRecord> listRecord = db.News.OrderByDescending(anhxa => anhxa.ID).ToList();
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
            NewsRecord record = db.News.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
            //goi view, truyen du lieu ra view
            return View("CreateUpdate", record);
        }
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            //---
            //lay ban ghi tuong ung voi id truyen vao
            var record = db.News.Where(tbl => tbl.ID == id).FirstOrDefault();
            //update ban ghi
            record.Name = _Name;
            record.Description = _Description;
            record.Content = _Content;
            record.Hot = _Hot;
            //---
            //lay thong tin o the file type="file"
            string _FileName = "";
            try
            {
                _FileName = Request.Form.Files[0].FileName;
            }
            catch {; }
            if (!String.IsNullOrEmpty(_FileName))
            {
                //xoa anh cu
                if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo)))
                {
                    //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                    //xoa anh
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo));
                }
                //upload anh moi
                //string _FileName = _file.FileName;
                //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                //lay duong dan cua file
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/News", _FileName);
                //upload file
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                //update gia tri vao cot Photo trong csdl
                record.Photo = _FileName;
            }
            //---
            //cap nhat ban ghi
            db.SaveChanges();
            //---
            return Redirect("/Admin/News");
        }
        //create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            //---
            //lay ban ghi tuong ung voi id truyen vao
            var record = new NewsRecord();
            //update ban ghi
            record.Name = _Name;
            record.Description = _Description;
            record.Content = _Content;
            record.Hot = _Hot;
            //---
            //lay thong tin o the file type="file"
            string _FileName = "";
            try
            {
                _FileName = Request.Form.Files[0].FileName;
            }
            catch {; }
            if (!String.IsNullOrEmpty(_FileName))
            {
                //upload anh moi
                //string _FileName = _file.FileName;
                //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                //lay duong dan cua file
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/News", _FileName);
                //upload file
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                //update gia tri vao cot Photo trong csdl
                record.Photo = _FileName;
            }
            //---
            //them ban ghi vao csdl
            db.News.Add(record);
            //cap nhat ban ghi
            db.SaveChanges();
            //---
            return Redirect("/Admin/News");
        }
        //xoa ban ghi
        public IActionResult Delete(int? id)
        {
            //lay ban ghi tuong ung voi id truyen vao
            var record = db.News.Where(tbl => tbl.ID == id).FirstOrDefault();
            //xoa anh cu
            if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo)))
            {
                //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                //xoa anh
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo));
            }
            //xoa ban ghi
            db.News.Remove(record);
            //cap nhat csdl
            db.SaveChanges();
            return Redirect("/Admin/News");
        }
    }
}
