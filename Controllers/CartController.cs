using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BTCK_PhanTienDo.Models;
// sd bien session khai bao doi tg nay 
using Microsoft.AspNetCore.Http;


namespace BTCK_PhanTienDo.Controllers
{
    public class CartController : Controller
    {
        // khoi tao doi tg thao tac csdl 
        public MyDbContext db = new MyDbContext();
        public IActionResult Index()
        {
            // lay cac sp trong goi gang 
            List<Item> _cart = Cart.GetCart(HttpContext.Session);
            if(_cart != null)
            {
                ViewBag._cart = _cart;
                ViewBag._total = _cart.Sum(tbl => (tbl.ProductItem.Price - (tbl.ProductItem.Price *tbl.ProductItem.Discount / 100))*tbl.Quantity);
            }
            return View();
        }
        // them gio hang 
        public IActionResult Buy(int id)
        {
            // goi hang CardAdd trong class cart de them phan tu vao gio hang
            Cart.CartAdd(HttpContext.Session, id);
            // di chuyen den 1 action dk chi dinh
            return RedirectToAction("Index", "Cart");
        }
        // xóa sp khỏi giỏ hàng 
        public IActionResult Remove(int id)
        {
            // goi ham CartRemove
            Cart.CartRemove(HttpContext.Session, id);
            return RedirectToAction("Index", "Cart");
        }
        // xao toan bọ 
        public IActionResult Destroy()
        {
            // goi ham Cartdestroy trong class cart de xoa cac phan tu khoi gio hang 
            Cart.CartDestroy(HttpContext.Session);

            return RedirectToAction("Index", "Cart");
        }
        //cap nhat so luong san pham trong gio hang
        public IActionResult Update()
        {
            //lay cac phan tu trong session cart
            List<Item> _cart = Cart.GetCart(HttpContext.Session);
            foreach (var item in _cart)
            {
                //lay so luong cua cac phan tu
                int quantity = Convert.ToInt32(Request.Form["product_" + item.ProductItem.ID]);
                //goi ham CartUpdate de update lai so luong san pham
                Cart.CartUpdate(HttpContext.Session, item.ProductItem.ID, quantity);
            }
            return RedirectToAction("Index", "Cart");
        }

        // thanh toan gio hang 
        public IActionResult Checkout()
        {
            // kiem tra neu User chua dang nhap thi yeu cau dang nhap 
            if(HttpContext.Session.GetString("email")== null)
            {
                return Redirect("/Account/Login");
            }
            else
            {
                List<Item> _cart = Cart.GetCart(HttpContext.Session);
                
                //lay custumer_id
                int customer_id = int.Parse(HttpContext.Session.GetString("customer_id"));
                //insert du lieu vao table Order
                OrdersRecord recordOrder = new OrdersRecord();
                recordOrder.CustomerID = customer_id;
                recordOrder.Create = DateTime.Now;
                recordOrder.Price = _cart.Sum(tbl => tbl.ProductItem.Price * tbl.Quantity);
                
                db.Orders.Add(recordOrder);

                db.SaveChanges();
                // lay id vua insert
                int order_id = recordOrder.ID;
                // duyet cac san pham tu trong session ,moi phan tu se add thanh 1 ban ghi trong order 
                foreach(var item in _cart)
                {
                    OrdersDetailRecord recordOrdersDetail = new OrdersDetailRecord();
                   
                    recordOrdersDetail.OrderID = order_id;
                    recordOrdersDetail.ProductID = item.ProductItem.ID;
                    recordOrdersDetail.Price = item.ProductItem.Price - (item.ProductItem.Price* item.ProductItem.Discount) / 100;
                    recordOrdersDetail.Quantity = item.Quantity;
                    db.OrdersDetail.Add(recordOrdersDetail);
                    db.SaveChanges();
                }
                
                // xoa tc 
                Cart.CartDestroy(HttpContext.Session);
                return Redirect("/Cart/DetailBill");

            }
        }
        public IActionResult DetailBill()
        {
            //lấy id của customer
            int customer_id = int.Parse(HttpContext.Session.GetString("customer_id"));
            ViewBag.idkh = customer_id;

            List<OrdersRecord> list = db.Orders.Where(tbl => tbl.CustomerID == customer_id && tbl.Status == 0).ToList();
            List<OrdersDetailRecord> listOrderDetail = new List<OrdersDetailRecord>();
            foreach (var item in list)
            {
                List<OrdersDetailRecord> listAll = db.OrdersDetail.Select(tbl => tbl).ToList();
                foreach (var item2 in listAll)
                {
                    if (item2.OrderID == item.ID)
                    {
                        listOrderDetail.Add(item2);
                    }
                }
            }

            return View("InformationBill", listOrderDetail);
        }
        public IActionResult deleteBill(int id)
        {
            int customer_id = int.Parse(HttpContext.Session.GetString("customer_id"));
            ViewBag.idkh = customer_id;

            OrdersDetailRecord record = db.OrdersDetail.Where(tbl => tbl.ID == id).FirstOrDefault();
            db.OrdersDetail.Remove(record);
            OrdersRecord order2 = db.Orders.Where(tbl => tbl.ID == record.OrderID).FirstOrDefault();
            order2.Price = order2.Price - record.Price;
            db.SaveChanges();

            List<OrdersRecord> order1 = db.Orders.ToList();
            var orderdetail1 = from d in db.OrdersDetail select d.OrderID;
            foreach (var item in order1)
            {
                if (!(orderdetail1.ToList().Contains(item.ID)))
                {
                    db.Orders.Remove(item);
                    db.SaveChanges();
                }
            }


            List<OrdersRecord> list = db.Orders.Where(tbl => tbl.CustomerID == customer_id  && tbl.Status == 0).ToList();
            List<OrdersDetailRecord> listOrderDetail = new List<OrdersDetailRecord>();
            foreach (var item in list)
            {
                List<OrdersDetailRecord> listAll = db.OrdersDetail.Select(tbl => tbl).ToList();
                foreach (var item2 in listAll)
                {
                    if (item2.OrderID == item.ID)
                    {
                        listOrderDetail.Add(item2);
                    }
                }


            }
            return View("InformationBill", listOrderDetail);
        }

    }
}


