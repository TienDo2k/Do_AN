//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using BTCK_PhanTienDo.Areas.Admin.Attributes;
//using BTCK_PhanTienDo.Models;
//using X.PagedList;

//namespace BTCK_PhanTienDo.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [CheckLogin]
//    public class ProductsController : Controller
//    {
//        MyDbContext db = new MyDbContext();
//        public IActionResult Index(int? page)
//        {
//            int currentPage = page ?? 1;
//            int recordPerpage = 20;
//            List<ProductsRecord> list = db.Products.OrderByDescending(tbl => tbl.ID).ToList();
//            return View("Index", list.ToPagedList(currentPage, recordPerpage));
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(IFormCollection fc)
//        {
//            string _Name = fc["Name"].ToString().Trim();
//            string _Price = fc["Price"].ToString().Trim();
//            string _Amount = fc["Amount"].ToString().Trim();
//            string _CategoryID = fc["CategoryID"].ToString().Trim();
//            string _Description = fc["Description"].ToString().Trim();
//            string _Content = fc["Content"].ToString().Trim();
//            string _Discount = fc["Discount"].ToString().Trim();
//            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;

//            if (fc["Name"].ToString() == "")
//            {
//                ViewBag.Failure = -1;
//                return View();
//            }
//            else if (fc["Price"].ToString() == "")
//            {
//                ViewBag.Failure = -2;
//                return View();
//            }
//            else if (fc["Amount"].ToString() == "")
//            {
//                ViewBag.Failure = -3;
//                return View();
//            }
//            else
//            {
//                var product = db.Products.Where(tbl => tbl.Name == _Name).FirstOrDefault();
//                if (product != null)
//                {
//                    product.Amount += Convert.ToInt32(_Amount);
//                }
//                else
//                {

//                    //---
//                    //lay ban ghi tuong ung voi id truyen vao
//                    var record = new ProductsRecord();
//                    //update ban ghi
//                    record.Name = _Name;
//                    record.Price = Convert.ToDouble(_Price);
//                    record.Discount = Convert.ToDouble(_Discount);
//                    record.CategoryID = Convert.ToInt32(_CategoryID);
//                    record.Amount = Convert.ToInt32(_Amount);
//                    record.Description = _Description;
//                    record.Content = _Content;
//                    record.Hot = _Hot;
//                    //---
//                    //lay thong tin o the file type="file"
//                    string _FileName = "";
//                    try
//                    {
//                        _FileName = Request.Form.Files[0].FileName;
//                    }
//                    catch {; }
//                    if (!String.IsNullOrEmpty(_FileName))
//                    {
//                        //upload anh moi
//                        //string _FileName = _file.FileName;
//                        //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
//                        var timestamp = DateTime.Now.ToFileTime();
//                        _FileName = timestamp + "_" + _FileName;
//                        //lay duong dan cua file
//                        string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Products", _FileName);
//                        //upload file
//                        using (var stream = new FileStream(_Path, FileMode.Create))
//                        {
//                            Request.Form.Files[0].CopyTo(stream);
//                        }
//                        //update gia tri vao cot Photo trong csdl
//                        record.Photo = _FileName;
//                    }
//                    //---
//                    //them ban ghi vao csdl
//                    db.Products.Add(record);
//                    //cap nhat ban ghi
//                    db.SaveChanges();
//                    //---

//                }
//            }
//            return RedirectToAction("Index");
//        }

//        public IActionResult Update(int? id)
//        {
//            /*
//             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
//                id = null
//             */
//            int _id = id ?? 0;
//            //lay mot ban ghi
//            ProductsRecord record = db.Products.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
//            //goi view, truyen du lieu ra view
//            return View(record);
//        }
//        [HttpPost]
//        public IActionResult Update(IFormCollection fc, int? id)
//        {
//            string _Name = fc["Name"].ToString().Trim();
//            string _Price = fc["Price"].ToString().Trim();
//            string _Amount = fc["Amount"].ToString().Trim();
//            string _CategoryID = fc["CategoryID"].ToString().Trim();
//            string _Description = fc["Description"].ToString().Trim();
//            string _Content = fc["Content"].ToString().Trim();
//            string _Discount = fc["Discount"].ToString().Trim();
//            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;

//            //---
//            //lay ban ghi tuong ung voi id truyen vao
//            if (fc["Name"].ToString() == "")
//            {
//                ViewBag.Failure = -1;
//                var record = new ProductsRecord();
//                record.Price = Convert.ToDouble(_Price);
//                record.Amount = Convert.ToInt32(_Amount);
//                record.Discount = Convert.ToDouble(_Discount);
//                record.CategoryID = Convert.ToInt32(_CategoryID);
//                record.Description = _Description;
//                record.Content = _Content;
//                record.Hot = _Hot;
//                return View(record);
//            }
//            else if (fc["Price"].ToString() == "")
//            {
//                ViewBag.Failure = -2;
//                var record = new ProductsRecord();
//                record.Name = _Name;

//                record.Amount = Convert.ToInt32(_Amount);
//                record.Discount = Convert.ToDouble(_Discount);
//                record.CategoryID = Convert.ToInt32(_CategoryID);
//                record.Description = _Description;
//                record.Content = _Content;
//                record.Hot = _Hot;
//                return View(record);
//            }
//            else if (fc["Amount"].ToString() == "")
//            {
//                ViewBag.Failure = -3;
//                var record = new ProductsRecord();
//                record.Name = _Name;
//                record.Price = Convert.ToDouble(_Price);

//                record.Discount = Convert.ToDouble(_Discount);
//                record.CategoryID = Convert.ToInt32(_CategoryID);
//                record.Description = _Description;
//                record.Content = _Content;
//                record.Hot = _Hot;
//                return View(record);
//            }
//            else
//            {


//                var record = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
//                //update ban ghi
//                record.Name = _Name;
//                record.Price = Convert.ToDouble(_Price);
//                record.Amount = Convert.ToInt32(_Amount);
//                record.Discount = Convert.ToDouble(_Discount);
//                record.CategoryID = Convert.ToInt32(_CategoryID);
//                record.Description = _Description;
//                record.Content = _Content;
//                record.Hot = _Hot;
//                //---
//                //lay thong tin o the file type="file"
//                string _FileName = "";
//                try
//                {
//                    _FileName = Request.Form.Files[0].FileName;
//                }
//                catch {; }
//                if (!String.IsNullOrEmpty(_FileName))
//                {
//                    //xoa anh cu
//                    if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
//                    {
//                        //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
//                        //xoa anh
//                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
//                    }
//                    //upload anh moi
//                    //string _FileName = _file.FileName;
//                    //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
//                    var timestamp = DateTime.Now.ToFileTime();
//                    _FileName = timestamp + "_" + _FileName;
//                    //lay duong dan cua file
//                    string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Products", _FileName);
//                    //upload file
//                    using (var stream = new FileStream(_Path, FileMode.Create))
//                    {
//                        Request.Form.Files[0].CopyTo(stream);
//                    }
//                    //update gia tri vao cot Photo trong csdl
//                    record.Photo = _FileName;
//                }
//                //---
//                //cap nhat ban ghi
//                db.SaveChanges();
//            }
//            //---
//            return Redirect("/Admin/Products");
//        }
//        public IActionResult Delete(int? id)
//        {
//            //lay ban ghi tuong ung voi id truyen vao
//            var record = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
//            //xoa anh cu
//            if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
//            {
//                //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
//                //xoa anh
//                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
//            }
//            //xoa ban ghi
//            db.Products.Remove(record);
//            //cap nhat csdl
//            db.SaveChanges();
//            return Redirect("/Admin/Products");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
//su dung doi tuong sau de thao tac voi ham IFormCollection
using Microsoft.AspNetCore.Http;
//su dung cac class ben trong thu muc Models
using BTCK_PhanTienDo.Models;
using Microsoft.EntityFrameworkCore;
// doi tuong thao tac file 
using System.IO;
using BTCK_PhanTienDo.Areas.Admin.Attributes;
namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class ProductsController : Controller
    {
        // khai bao bien toan cuc la bien de thao tac csdl 
        public MyDbContext db = new MyDbContext();
        public IActionResult Index(int? page)
        {
            // lay trang hien tai
            // page ?? 1
            // neu page ma khac null thi _currentPgae = Page 
            // con lai thi Crurrnt page =1
            int _CurrentPage = page ?? 1;
            // quy dinh so ban ghi tren 1 trang 
            // lay tat ca cac ban ghi trong Users
            // qd số bản ghi trên 1 trang
            int _RecordPerPage = 20;

            //anhxa => anhxa.ID ->ss giam dan cot Id(tu gia tri cao nhat den thap nhat) 
            List<ProductsRecord> listRecord = db.Products.OrderByDescending(anhxa => anhxa.ID).ToList();
            // truyen gia tri ra views co phan trang 
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        // mac dinh trang thai cau trang laf GET-> k can dinh nghia tt trang bnag lenh 
        //[HttpGet]
        public IActionResult Update(int? id)
        {
            /* int? id : neu co gtri truyen vao thi id = gtri , neu k co thi lay null
             */
            int _id = id ?? 0;
            // lay 1 ban ghi 
            ProductsRecord record = db.Products.Where(anhxa => anhxa.ID == _id).FirstOrDefault();
            //goi view, truyen du lieu ra view
            return View("CreateUpdate", record);
        }
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Price = fc["Price"].ToString().Trim();
            string _CategoryID = fc["CategoryID"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Discount = fc["Discount"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            string _Amount = fc["Amount"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            // layt ban ghi tg ung 
            var record = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
            //Update ban ghi
            record.Name = _Name;
            record.Price = Convert.ToDouble(_Price);
            record.Discount = Convert.ToDouble(_Discount);
            record.CategoryID = Convert.ToInt32(_CategoryID);
            record.Description = _Description;
            record.Content = _Content;
            record.Amount = Convert.ToInt32(_Amount);
            record.Hot = _Hot;
            //---
            // lay thong tin o file type="file"
            string _FileName = "";
            try
            {
                _FileName = Request.Form.Files[0].FileName;
            }
            catch {; }

            if (!String.IsNullOrEmpty(_FileName))
            {
                //xoa anh cu 
                if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
                {
                    //-> Path.Combine-> get cac tham so ben trong no thanh chuoi
                    //xoa anh 
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
                }
                //upload anh moi 
                //string _FileName = _file.FileName;
                // lay thoi gian vao ten file - >tranh cac file trung ten se upload de nhau 
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                // lay dg dan file 
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", _FileName);
                // upload file 
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                //update gia tri vao cot Photo trong CSDl
                record.Photo = _FileName;
            }


            //---
            // cap nhat ban ghi 
            db.SaveChanges();
            return Redirect("/Admin/Products");

        }
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Price = fc["Price"].ToString().Trim();
            string _CategoryID = fc["CategoryID"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Discount = fc["Discount"].ToString().Trim();
            string _Amount= fc["Amount"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            // layt ban ghi tg ung 
            var record = new ProductsRecord();
            //Update ban ghi
            record.Name = _Name;
            record.Price = Convert.ToDouble(_Price);
            record.Discount = Convert.ToDouble(_Discount);
            record.CategoryID = Convert.ToInt32(_CategoryID);
            record.Amount = Convert.ToInt32(_Amount);
            record.Description = _Description;
            record.Content = _Content;
            record.Hot = _Hot;
            //---
            // lay thong tin o file type="file"

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
                // lay thoi gian vao ten file - >tranh cac file trung ten se upload de nhau 
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                // lay dg dan file 
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", _FileName);
                // upload file 
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                db.Products.Add(record);
                //update gia tri vao cot Photo trong CSDl
                record.Photo = _FileName;
            }


            //---
            // cap nhat ban ghi 
            db.SaveChanges();
            return Redirect("/Admin/Products");

        }
        public IActionResult Delete(int? id)
        {
            var record = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
            if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
            {
                //-> Path.Combine-> get cac tham so ben trong no thanh chuoi
                //xoa anh 
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
            }
            // xoa ban ghi
            db.Products.Remove(record);
            // cap nhat csdl 
            db.SaveChanges();
            return Redirect("/Admin/Products");
        }
    }
}

