using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Models;
// phan trang 
using X.PagedList;
// thao tac vs file 
using System.IO;
// sd cho IformFile 
using Microsoft.AspNetCore.Http;
namespace BTCK_PhanTienDo.Controllers
{
    
    public class SearchController : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult SearchPrice(int ? page)
        {
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            double fromPrice = !String.IsNullOrEmpty(Request.Query["fromPrice"]) ? Convert.ToDouble(Request.Query["fromPrice"]) : 0;
            double toPrice = !String.IsNullOrEmpty(Request.Query["toPrice"]) ? Convert.ToDouble(Request.Query["toPrice"]) : 0;
            List<ProductsRecord> listRecord = db.Products.Where(tbl => tbl.Price >= fromPrice && tbl.Price <= toPrice).OrderByDescending(tbl => tbl.ID).ToList();
            //tìm kiếm theo giá sau khi giảm giá 
            //List<ProductsRecord> listRecord = db.Products.Where(tbl => (tbl.Price - (tbl.Price  tbl.Discount) / 100) >= fromPrice && (tbl.Price - (tbl.Price  tbl.Discount) / 100) <= toPrice).OrderByDescending(tbl => tbl.ID).ToList();
            return View("SearchPrice", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        public IActionResult SearchProducts(int? page)
        {
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            string key = !String.IsNullOrEmpty(Request.Query["key"]) ? Request.Query["key"] : "";
            List<ProductsRecord> listRecord = db.Products.Where(tbl => tbl.Name.Contains(key)).ToList();

            return View("SearchProducts", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        public string AJax()
        {
           
            string key = !String.IsNullOrEmpty(Request.Query["key"]) ? Request.Query["key"] : "";
            List<ProductsRecord> listRecord = db.Products.Where(tbl => tbl.Name.Contains(key)).ToList();
            string str = "";
            foreach (var item in listRecord)
            {
                str = str + "<li><a href='/Products/Detail/" + item.ID + "'><img src='/Upload/Products/" + item.Photo + "'/> " + item.Name + "</a></li>";
            }
            return str;
        }
    }
}
