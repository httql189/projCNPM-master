using Model.Dao;
using projCNPM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           var sess = (UserLogin)Session[CommonConstant.ADMIN_SESSION];
          
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admin" }));
            }
            else
            {
                var user = new UserDao().GetByID(sess.UserName);
                if (user.GroupID!="ADMIN")
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admin" }));
                }

            }

            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";

            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}