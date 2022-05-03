using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Areas.Admin.Attributes;
using BTCK_PhanTienDo.Models;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class PermissionController : Controller
    {
        MyDbContext db = new MyDbContext();
        public IActionResult Index(int? id)
        {
            int _id = id ?? 0;
            RoleRecord record = db.Role.Where(tbl => tbl.UserId == _id).FirstOrDefault();
            return View("Index",record);
        }
        [HttpPost]
        public IActionResult Index(IFormCollection fc,int? id)
        {
            int _id = id ?? 0;
            int menuCategory= fc["MenuCategory"] != "" && fc["MenuCategory"] == "on" ? 1 : 0;
            int menuProduct= fc["MenuProduct"] != "" && fc["MenuProduct"] == "on" ? 1 : 0;
            int menuOrder= fc["MenuOrder"] != "" && fc["MenuOrder"] == "on" ? 1 : 0;
            int menuUser= fc["MenuUser"] != "" && fc["MenuUser"] == "on" ? 1 : 0;
            RoleRecord role = db.Role.Where(tbl => tbl.UserId == _id).FirstOrDefault();
            role.MenuCategory = menuCategory;
            role.MenuProduct = menuProduct;
            role.MenuOrder = menuOrder;
            role.MenuUser = menuUser;
            db.SaveChanges();
            return Redirect("/Admin/User");
        }
    }
}
