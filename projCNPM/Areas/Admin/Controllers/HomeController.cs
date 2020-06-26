using Model.Dao;
using Model.EF;
using projCNPM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        OnlineSMSystemDB db = new OnlineSMSystemDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details()
        {
            //var dao = new UserDao();
            var session = (UserLogin)Session[CommonConstant.ADMIN_SESSION];
            var user = session.UserId;
            Member member = db.Members.Find(user);
            return View(member);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            //var dao = new UserDao();
            var session = (UserLogin)Session[CommonConstant.ADMIN_SESSION];
            var user = session.UserId;
            Member member = db.Members.Find(user);
            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member admin)
        {
            var admindao = new UserDao();

            

                if (admin.LastName == null) ModelState.AddModelError("", "LastName is not empty!!!");
                else if (admin.FirstName == null) ModelState.AddModelError("", "FistName is not empty!!!");
                else if (admin.BirthDate == null) ModelState.AddModelError("", "BirthDay is not empty!!!");
                else if (admin.LastName == null) ModelState.AddModelError("", "LastName is not empty!!!");
                else if (admin.District == null) ModelState.AddModelError("", "District is not empty!!!");
                else if (admin.Province == null) ModelState.AddModelError("", "Province is not empty!!!");
                else if (admin.Email == null) ModelState.AddModelError("", "Email is not empty!!!");
                else if (admin.CMND == null) ModelState.AddModelError("", "CMND is not empty!!!");
                else if (admin.Phone ==null) ModelState.AddModelError("", "Phone is not empty!!!");
                else if (admindao.CheckMemberPhone(admin.Phone)) ModelState.AddModelError("", "Phone has been used!!");
                else if (admindao.CheckUserEmail(admin.Phone)) ModelState.AddModelError("", "Email has been used!!");
                else
                {
                    var result = admindao.EditAdmin(admin);
                    if (result)
                    {

                    SetAlert("Update Profile Success!!", "success");
                        return RedirectToAction("Details","Home");
                    }
                    else
                    {
                    //SetAlert("Update Profile Success!!", "success");
                    ModelState.AddModelError("", "Update Profiles Fail!!!");
                    }
                }
            return View();

            
         
  

            

        }
    }
}