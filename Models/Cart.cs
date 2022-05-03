using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
// muốn sử thu vien json thì them dòng này 
using Newtonsoft.Json;

namespace BTCK_PhanTienDo.Models
{
    public class Cart
    {
        protected static readonly MyDbContext db = new MyDbContext();
        //------        
        public static T GetObjectFromJson<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        //------
        //lay gio hang dang ton tai
        public static List<Item> GetCart(ISession session)
        {
            //JsonConvert.DeserializeObject<T>("cart")
            List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");
            return cart;
        }
        //add item to cart
        public static void CartAdd(ISession session, int id)
        {
            // giỏ rỗng 
            if (Cart.GetObjectFromJson<List<Item>>(session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                ProductsRecord item = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
                if (item.Amount > 0)
                {
                    cart.Add(new Item { ProductItem = item, Quantity = 1 });
                
                    item.Amount = item.Amount - 1;
                    db.SaveChanges();
                }
                session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");
               
                int index = Cart.isExist(session,id);
                //hàng đã có trong giỏ 
                if (index != -1)
                {
                    ProductsRecord item = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
                    if (item.Amount > 0)
                    {
                        cart[index].Quantity++;
                        item.Amount = item.Amount - 1;
                        db.SaveChanges();
                    }
                    
                }
                // mặt hàng khác 
                else
                {
                    ProductsRecord item = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
                    if (item.Amount > 0)
                    {
                        cart.Add(new Item { ProductItem = item, Quantity = 1 });
                        item.Amount = item.Amount - 1;
                        db.SaveChanges();
                    }
                }
                session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
        }
        //remove item in cart
        public static void CartRemove(ISession session, int id)
        {
           

            List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");

            int index = isExist(session,id);
  
            cart.RemoveAt(index);

            List<Item> n = itemIsExist( session,id);
            foreach(var item  in n) {
                ProductsRecord pr = db.Products.Where(tbl => tbl.ID == item.ProductItem.ID).FirstOrDefault();

                pr.Amount = pr.Amount + item.Quantity;
            }
            db.SaveChanges();

            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        //remove all item in cart
        public static void CartDestroy(ISession session)
        {
            // lấy giỏ hàng ban đầu khi chưa bị xóa
            List<Item> oldCart = GetCart(session);
            for (int i = 0; i < oldCart.Count; i++)
            {
                ProductsRecord item = db.Products.Where(tbl => tbl.ID == oldCart[i].ProductItem.ID).FirstOrDefault();
                item.Amount = item.Amount + oldCart[i].Quantity;
            }
            db.SaveChanges();
            // tạo giỏ hàng mới 
            List<Item> cart = new List<Item>();

            session.SetString("cart", JsonConvert.SerializeObject(cart));
          
        }
        public static void CartUpdate(ISession session, int id, int quantity)
        {
            
            List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");
            //---
            for (int i = 0; i < cart.Count; i++)
            {
               

                if (cart[i].ProductItem.ID == id)
                {
                    cart[i].Quantity = quantity;
                    ProductsRecord item = db.Products.Where(tbl => tbl.ID == id).FirstOrDefault();
                    item.Amount = item.Amount - (quantity - 1) ;
                }
                db.SaveChanges();
            }
            //---
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        private static int isExist(ISession session, int id)
        {
            List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductItem.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        // lấy các sản phẩm trong giỏ hàng 
        private static List<Item> itemIsExist(ISession session, int id)
        {
            List<Item> cart = Cart.GetObjectFromJson<List<Item>>(session, "cart");
            List<Item> newItem = new List<Item>();
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductItem.ID == id)
                {
                    newItem.Add(cart[i]);
                    return newItem;
                }
            }
            return null ;
        }
    }
}
