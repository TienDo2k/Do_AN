using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//nhin thay cac file trong thu muc Models
using BTCK_PhanTienDo.Models;
//phan trang
using X.PagedList;
//thao tac voi file
using System.IO;
//su dung cho IFormFile
using Microsoft.AspNetCore.Http;

namespace BTCK_PhanTienDo.Controllers
{
    public class NewsController : Controller
    {
        public MyDbContext db = new MyDbContext();
        public IActionResult Index(int? page)
        {
            //lay trang hien tai
            //page ?? 1
            //neu page khac null thi _CurrentPage = page
            //neu page =  null thi _CurrentPage = 1
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            List<NewsRecord> listRecord = new List<NewsRecord>();            
            listRecord = db.News.OrderByDescending(anhxa => anhxa.ID).ToList();
            //---
            //truyen gia tri ra view co phan trang
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        //chi tiet san pham
        public IActionResult Detail(int? id)
        {
            int intID = id ?? 0;
            NewsRecord record = db.News.Where(tbl => tbl.ID == intID).FirstOrDefault();
            return View("Detail", record);
        }
    }
}
