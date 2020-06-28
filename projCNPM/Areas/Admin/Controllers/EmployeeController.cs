using Microsoft.Ajax.Utilities;
using Model.Dao;
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
       
        [HttpGet]
        public ActionResult Index()
        {
           
            var employee = db.Members.Where(x => x.GroupID == "NV").ToList();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Index(long id, bool? status)
        {
            var change = new UserDao();
            if (!change.ChangeStatusEmployee(id, status))
                SetAlert("Update Profile Fail!!", "Fail");
            else
            {
                SetAlert("Update Status Successfully!!", "success");
                var employee = db.Members.Where(x => x.GroupID == "NV").ToList();
                return RedirectToAction("Index", FormMethod.Get);
            }
            return View();
          
        }
        public bool? updateStatus(int id)
        {
           var emp = db.Members.Find(id);
            emp.Status = !emp.Status;
            db.SaveChanges();
            return !emp.Status;
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = updateStatus(id);
            return Json("thành công", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(long id)
        {
            var employee = db.Members.Where(x => x.MemberID == id).SingleOrDefault();
            return View(employee);
        }
        public ActionResult myModal(int Id)
        {
            ViewBag.type = 1;
            var employee = db.Members.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Areas/Admin/Views/Employee/_myModal.cshtml", employee);

        }

    }
}