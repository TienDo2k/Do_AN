using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Areas.Admin.Attributes;
using BTCK_PhanTienDo.Models;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.IO;
using OfficeOpenXml;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class OrdersController : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly string _toEmail;
        private readonly string _subject;
        private readonly string _context;
        private readonly string _fromEmail;
        private readonly string _fromEmailDisplayName;
        private readonly string _fromEmailPassword;
        private readonly string _stmpHost;
        private readonly string _stmpPost;
        private readonly bool _enabledSsl;
        public OrdersController(IConfiguration config)
        {
            _fromEmail = config["Email:FromEmail"].ToString();
            _fromEmailDisplayName = config["Email:FromEmailDisplayName"].ToString();
            _fromEmailPassword = config["Email:FromEmailPassword"].ToString();
            _stmpHost = config["Email:SMTPHost"].ToString();
            _stmpPost = config["Email:SMTPPost"].ToString();
            _enabledSsl = bool.Parse(config["Email:EnabledSSL"].ToString());
        }
        public IActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int perPage = 3;
            List<OrdersRecord> list = db.Orders.OrderByDescending(o => o.ID).ToList();

            return View("Index",list.ToPagedList(currentPage,perPage));
        }
        public IActionResult Detail(int? id)
        {
            int _id = id ?? 0;
            ViewBag.orderID = _id;
            List<OrdersDetailRecord> listRecord = db.OrdersDetail.Where(tbl => tbl.OrderID == _id).ToList();
            
            return View("Detail", listRecord);
        }
      
        public IActionResult Delivery(int? id)
        {
            int _id = id ?? 0;
            OrdersRecord record = db.Orders.Where(o => o.ID == _id).FirstOrDefault();
            record.Status = 1;
            db.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }
        public IActionResult Export(int? id)
        {
            int _id = id ?? 0;
            //id order
            ViewBag.orderID = _id;
            OrdersRecord record = db.Orders.Where(tbl => tbl.ID == _id).FirstOrDefault();
            //trả ra khách hàng
            CustomersRecord cusRecord = db.Customers.Where(tbl => tbl.ID == record.CustomerID).FirstOrDefault();
            // trả ra detail
            OrdersDetailRecord detailRecord = db.OrdersDetail.Where(tbl => tbl.OrderID == record.ID).FirstOrDefault();
            // trong detail có IDproduct 
            List<ProductsRecord> productsRecords = db.Products.Where(tbl => tbl.ID == detailRecord.ID).ToList();
            var fileName = $"ChiTietDonHang_{DateTime.Now.ToString("d")}.xlsx";
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("ChiTietDonHang");
                sheet.Cells[1, 1].Value = "Thông tin khách hàng";
                sheet.Cells[2, 1].Value = "Họ tên";
                sheet.Cells[2, 2].Value = "Địa chỉ";
                sheet.Cells[2, 3].Value = "Số điện thoại";
                sheet.Cells[2, 4].Value = "Trạng thái giao hàng";
                int index = 3;

                package.Save();

            }
            stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
