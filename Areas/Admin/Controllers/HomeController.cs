using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Areas.Admin.Attributes;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
