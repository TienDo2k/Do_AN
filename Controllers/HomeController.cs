using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCK_PhanTienDo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HttpContext.Response.Redirect("Admin/Account/Login");
            //return Content("");
            //////return Redirect("Admin/Account/Login");
            return View();
        }
    }
}
