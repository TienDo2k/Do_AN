using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCK_PhanTienDo.Areas.Admin.Attributes
{
    public class CheckLogin:ActionFilterAttribute
    {
        public HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //_httpContext.Session.GetString("email"): lấy biến session email
            //để sử dụng duongf dưới phải cài gói nuget session
            string _email = _httpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(_email))

                _httpContext.Response.Redirect("/Admin/Account/Login");

            base.OnActionExecuting(context);
        }
    }
}
