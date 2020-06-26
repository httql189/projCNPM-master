using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Areas.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Admin/Employee
        OnlineSMSystemDB db = new OnlineSMSystemDB();
        public ActionResult Index()
        {
            var employee = db.Members.Where(x => x.GroupID == "NV").ToList();
            return View(employee);
        }
        public ActionResult Edit()
        {
            var employee = db.Members.Where(x => x.GroupID == "NV").ToList();
            return View(employee);
        }

    }
}