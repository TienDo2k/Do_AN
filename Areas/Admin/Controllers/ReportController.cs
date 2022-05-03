
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Areas.Admin.Attributes;
using BTCK_PhanTienDo.Models;

namespace BTCK_PhanTienDo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class ReportController : Controller
    {
        String strConnect = "";
        public ReportController(IConfiguration confi)
        {
            strConnect = confi.GetConnectionString("DBConnectString");
        }
        public IActionResult Index()
        {
            var nowDate = DateTime.Now;
            var fromDate = new DateTime(nowDate.Year, nowDate.Month, 1);
            var toDate = DateTime.Now.AddDays(-1);
            ViewBag.StartDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.EndDate = toDate.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(strConnect))
            //{
            //    //con.Open();
            //    //SqlCommand command = new SqlCommand("select [Create], sum(tblOrders.Price) as Price from tblOrders group by tblOrders.[Create]");
            //    //SqlDataAdapter adap = new SqlDataAdapter(command);
            //    //adap.Fill(data);
            //    //con.Close();
            //    con.Open();
            //    using (SqlCommand cmd = con.CreateCommand())
            //    {
            //        //sample stored procedure with parameter:
            //        // "exec yourstoredProcedureName '" + param1+ "','" + param2+ "'";
            //        cmd.CommandText = "select [Create], sum(tblOrders.Price) as Price from tblOrders where Status =1 and [Create]=" + fromDate.ToString("yyyy-MM-dd") + " and [Create]=" + toDate.ToString("yyyy-MM-dd") + "  group by tblOrders.[Create]";
            //        //cmd.CommandType = CommandType.StoredProcedure;
            //        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            //        {
            //            adp.Fill(dt);

            //        }
            //    }
            //}
            return View(dt);
        }
        [HttpPost]
        public IActionResult Index(string startDate, string endDate)
        {
            var nowDate = DateTime.Now;
            var fromDate = new DateTime(nowDate.Year, nowDate.Month, 1);
            DateTime toDate = DateTime.Now.AddDays(-1);
            if (!string.IsNullOrEmpty(startDate))
            {
                fromDate = Convert.ToDateTime(startDate.Trim());
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                toDate = Convert.ToDateTime(endDate.Trim());
            }
            ViewBag.StartDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.EndDate = toDate.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnect))
            {
                //con.Open();
                //SqlCommand command = new SqlCommand("select [Create], sum(tblOrders.Price) as Price from tblOrders group by tblOrders.[Create]");
                //SqlDataAdapter adap = new SqlDataAdapter(command);
                //adap.Fill(data);
                //con.Close();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    //sample stored procedure with parameter:
                    // "exec yourstoredProcedureName '" + param1+ "','" + param2+ "'";
                    cmd.CommandText = "select [Create], sum(Orders.Price) as Price from Orders where Status =1 and [Create] >='" + fromDate.ToString("yyyy-MM-dd") + "' and [Create] <='" + toDate.ToString("yyyy-MM-dd") + "'  group by Orders.[Create]";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);

                    }
                }
            }

            return View("Index", dt);
        }
    }
}
