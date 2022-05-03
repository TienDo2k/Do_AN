using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BTCK_PhanTienDo.Models;
//su dung bien session phai khai bao doi tuong nay
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BTCK_PhanTienDo.Controllers
{
    public class WishListController : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult Index()
        {
            //lay chuoi string json luu o bien session
            string strWishList = "";
            if (HttpContext.Session.GetString("jsonWishList") != null)
                strWishList = HttpContext.Session.GetString("jsonWishList");
            List<ProductsRecord> listWishList = new List<ProductsRecord>();
            //convert chuoi json sang kieu List
            listWishList = JsonConvert.DeserializeObject<List<ProductsRecord>>(strWishList);
            //return Content(strWishList);
            return View("Index", listWishList);
        }
        public IActionResult Create(int? id)
        {
            int _id = id ?? 0;
            //lay chuoi string json luu o bien session
            string strWishList = "";
            if (HttpContext.Session.GetString("jsonWishList") != null)
                strWishList = HttpContext.Session.GetString("jsonWishList");
            List<ProductsRecord> listWishList = new List<ProductsRecord>();
            if (!string.IsNullOrEmpty(strWishList))
            {
                //convert chuoi json sang kieu List
                listWishList = JsonConvert.DeserializeObject<List<ProductsRecord>>(strWishList);
                bool flag = false;
                foreach(ProductsRecord item in listWishList)
                {
                    if (item.ID == id)
                        flag = true;
                }
                if(flag == false)
                {
                    //lay ban ghi de add
                    ProductsRecord record = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
                    listWishList.Add(record);
                    //convert kieu list sang chuoi json
                    strWishList = JsonConvert.SerializeObject(listWishList);
                    //gan vao bien session
                    HttpContext.Session.SetString("jsonWishList", strWishList);
                }
            }
            else
            {
                ProductsRecord record = db.Products.Where(tbl=>tbl.ID == id).FirstOrDefault();
                listWishList.Add(record);
                //convert kieu list sang chuoi json
                strWishList = JsonConvert.SerializeObject(listWishList);
                //gan vao bien session
                HttpContext.Session.SetString("jsonWishList", strWishList);
                //return Content(strWishList);
            }
            return Redirect("/WishList");
        }
        public IActionResult Remove(int? id)
        {
            int _id = id ?? 0;
            ProductsRecord record = db.Products.Where(tbl => tbl.ID == _id).FirstOrDefault();
            string strWishList = "";
            if (HttpContext.Session.GetString("jsonWishList") != null)
            {
                strWishList = HttpContext.Session.GetString("jsonWishList");
                List<ProductsRecord> listWishList = new List<ProductsRecord>();
                listWishList = JsonConvert.DeserializeObject<List<ProductsRecord>>(strWishList);
                //return Content(listWishList.Count.ToString());
                int n = 0;
                int nRemove = 0;
                foreach(ProductsRecord item in listWishList)
                {
                    if (item.ID == _id)
                        nRemove = n;
                    n++;
                }
                listWishList.RemoveAt(nRemove);
                //convert kieu list sang chuoi json
                strWishList = JsonConvert.SerializeObject(listWishList);
                //gan vao bien session
                HttpContext.Session.SetString("jsonWishList", strWishList);
            }
            return Redirect("/WishList");
        }
    }
}
