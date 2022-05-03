using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Models;
using X.PagedList;
using System.IO;
using Microsoft.AspNetCore.Http;
namespace BTCK_PhanTienDo.Controllers
{
    public class Products : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult Category(int? id, int? page)
        {
            int intCategoryID = id ?? 0;

            //lay trang hien tai
            //page ?? 1
            //neu page khac null thi _CurrentPage = page
            //neu page =  null thi _CurrentPage = 1
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            List<ProductsRecord> listRecord = new List<ProductsRecord>();
            //lay bien order truyen tu url
            string _order = !String.IsNullOrEmpty(Request.Query["order"]) ? Request.Query["order"] : "";
            switch (_order)
            {
                case "priceAsc":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID).OrderBy(anhxa => anhxa.Price).ToList();
                    break;
                case "priceDesc":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID).OrderByDescending(anhxa => anhxa.Price).ToList();
                    break;
                case "nameAsc":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID).OrderBy(anhxa => anhxa.Name).ToList();
                    break;
                case "nameDesc":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID).OrderByDescending(anhxa => anhxa.Name).ToList();
                    break;
                    //tìm kiếm theo mức giá sử dụng checkbox
                case "p500":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID &&tbl.Price<500000).ToList();
                    break;
                case "p500_1000":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID && tbl.Price >=500000 &&tbl.Price<1000000).ToList();
                    break;
                case "p1000_1500":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID && tbl.Price >= 1000000 && tbl.Price < 1500000).ToList();
                    break;
                case "p2000_5000":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID && tbl.Price >= 2000000 && tbl.Price < 5000000).ToList();
                    break;
                case "p5000":
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID && tbl.Price > 5000000).ToList();
                    break;
                default:
                    listRecord = db.Products.Where(tbl => tbl.CategoryID == intCategoryID).OrderByDescending(anhxa => anhxa.ID).ToList();
                    break;
            }
            //---
            //truyen gia tri ra view co phan trang
            return View("Category", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        // chi tiet sp
        public IActionResult Detail(int? id)
        {
            int intID = id ?? 0;
            ProductsRecord record = db.Products.Where(tbl => tbl.ID == intID).FirstOrDefault();
            return View("Detail", record);
        }
        // danh gia so sao 

        public IActionResult Star(int? id)
        {
            int intStar = !String.IsNullOrEmpty(Request.Query["star"]) ? Convert.ToInt32(Request.Query["star"]) : 0;
            int intProductID = id ?? 0;
            RatingRecord record = new RatingRecord();
            record.ProductID = intProductID;
            record.Star = intStar;
            // them ban ghi
            db.Rating.Add(record);
            // cap nhat lai csdl 
            db.SaveChanges();
            return Redirect("/Products/Detail/" + intProductID);
        }

    }
}
