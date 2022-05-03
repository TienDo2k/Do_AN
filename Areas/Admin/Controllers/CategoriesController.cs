//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BTCK_PhanTienDo.Areas.Admin.Attributes;
//using BTCK_PhanTienDo.Areas.Admin.Models;
//using BTCK_PhanTienDo.Models;

//namespace BTCK_PhanTienDo.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [CheckLogin]
//    public class CategoriesController : Controller
//    {
//        MyDbContext db = new MyDbContext();
//        public IActionResult Index()
//        {
//            List<CategoriesRecord> list = db.Categories.ToList();

//            return View(list);
//        }
//        public IActionResult Create()
//        {
//            CategoryForm record = new CategoryForm();
//            return View(record);
//        }
//        [HttpPost]
//        public IActionResult Create(CategoryForm model)
//        {

//            if (ModelState.IsValid)
//            {
//                var record = db.Categories.Where(tbl => tbl.Name == model.Name).FirstOrDefault();
//                if(record != null)
//                {
//                    ViewBag.Failure = -1;
//                    return View(model);
//                }else if(model.Name == null)
//                {
//                    ViewBag.Failure = 0;
//                    return View(model);
//                }
//                else
//                {
//                    ViewBag.Failure = 1;
//                    CategoriesRecord cate = new CategoriesRecord();
//                    cate.Name = model.Name;
//                    db.Categories.Add(cate);
//                    db.SaveChanges();
//                }
//            }
//            return RedirectToAction("Index");
//        }
//        public IActionResult Update(int id)
//        {
//            CategoriesRecord record = db.Categories.Where(tbl =>tbl.ID == id).FirstOrDefault();
//            return View(record);
//        }
//        [HttpPost]
//        public IActionResult update(CategoriesRecord model)
//        {
//            if (ModelState.IsValid)
//            {
//                var record = db.Categories.Where(tbl => tbl.Name == model.Name && tbl.ID != model.ID).FirstOrDefault();
//                if (record != null)
//                {
//                    ViewBag.Failure = -1;
//                    return View(model);
//                }
//                else if (model.Name == null)
//                {
//                    ViewBag.Failure = 0;
//                    return View(model);
//                }
//                else
//                {
//                    ViewBag.Failure = 1;
//                    var cate = db.Categories.Where(tbl => tbl.ID == model.ID).FirstOrDefault();
//                    cate.Name = model.Name;

//                    db.SaveChanges();
//                }
//            }
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int id)
//        {
//            List<ProductsRecord> listProduct = db.Products.Where(tbl => tbl.CategoryID == id).ToList();
//            if(listProduct.Count == 0)
//            {
//                CategoriesRecord record = db.Categories.Where(tbl => tbl.ID == id).FirstOrDefault();
//                db.Categories.Remove(record);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;//doc file appsettings.json
using System.Data;//su dung doi tuong DataTable, DataSet, DataAdapter
using System.Data.SqlClient; //su dung doi tuong SqlConnection
using Microsoft.AspNetCore.Http;//su dung doi tuong IFormCollection
using BTCK_PhanTienDo.Areas.Admin.Attributes;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    //khai bao phan vung Admin
    [Area("Admin")]
    //xac thuc dang nhap
    [CheckLogin]
    public class CategoriesController : Controller
    {
        //khai bao chuoi ket noi
        string strDBConnectString = "";
        //ham tao la ham duoc tu dong goi len
        public CategoriesController(IConfiguration configuration)
        {
            strDBConnectString = configuration.GetConnectionString("DBConnectString");
        }
        public IActionResult Index()
        {
            //---
            //quy dinh so ban ghi tren mot trang
            double recordPerPage = 20;
            //tinh tong so ban ghi
            double totalRecord = GetTotalRecord();
            //tinh so trang
            //Math.Ceiling lay gia tri tran. VD: 2.1 = 3; 2.6 = 3
            ViewBag.numPage = Math.Ceiling(totalRecord / recordPerPage);
            //lay bien page truyen tu url
            int page = !string.IsNullOrEmpty(Request.Query["page"]) ? Convert.ToInt32(Request.Query["page"]) - 1 : 0;
            //lay tu ban ghi nao
            int from = Convert.ToInt32(recordPerPage) * page;
            //---
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                //lay cac san pham cap cha (ParentID = 0)
                SqlDataAdapter da = new SqlDataAdapter("select * from Categories where ParentID = 0 order by ID desc offset " + from + " rows fetch next " + recordPerPage + " rows only", conn);
                //do ket qua truy van vao DataTable dt
                da.Fill(dt);
            }
            return View("Index", dt);
        }
        //ham tra ve tong so ban ghi
        public double GetTotalRecord()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                //lay cac san pham cap cha (ParentID = 0)
                SqlDataAdapter da = new SqlDataAdapter("select ID from Categories where ParentID = 0", conn);
                //do ket qua truy van vao DataTable dt
                da.Fill(dt);
            }
            return dt.Rows.Count;
        }
        // update 
        public IActionResult Update(int? id)
        {
            int _id = id ?? 0;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                //lay cac san pham cap cha (ParentID = 0)
                SqlDataAdapter da = new SqlDataAdapter("select * from Categories where id= " + _id, conn);
                //do ket qua truy van vao DataTable dt
                da.Fill(dt);
            }
            // tra ve 1 dong  

            return View("CreateUpdate", dt.Rows[0]);
        }
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            int _id = id ?? 0;
            string strName = fc["Name"].ToString().Trim();
            int intParentID = Convert.ToInt32(fc["ParentID"].ToString());
            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                SqlCommand cmd = new SqlCommand("update Categories set Name=@tenNhap ,ParentID=@paramParentID where ID=@id", conn);
                cmd.Parameters.AddWithValue("tenNhap", strName);
                cmd.Parameters.AddWithValue("paramParentID", intParentID.ToString());
                cmd.Parameters.AddWithValue("id", _id.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Redirect("/Admin/Categories");
        }
        // create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string strName = fc["name"].ToString().Trim();
            int intParentID = Convert.ToInt32(fc["ParentID"].ToString());
            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                SqlCommand cmd = new SqlCommand("insert into Categories(Name,ParentID) values(@paramName,@paramParentID)", conn);
                cmd.Parameters.AddWithValue("paramName", strName);
                cmd.Parameters.AddWithValue("paramParentID", intParentID.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Redirect("/Admin/Categories");
        }
        public IActionResult Delete(IFormCollection fc, int? id)
        {
            int _id = id ?? 0;

            using (SqlConnection conn = new SqlConnection(strDBConnectString))
            {
                // xoa danh muc cha va cac danh muc con thuoc danh muc cah do 
                SqlCommand cmd = new SqlCommand("delete from Categories where ID = @paramID or ParentID=@paramID", conn);

                cmd.Parameters.AddWithValue("paramID", _id.ToString());
                // insert , update, delete phai mo csdl ra 
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return Redirect("/Admin/Categories");
        }

    }
}
