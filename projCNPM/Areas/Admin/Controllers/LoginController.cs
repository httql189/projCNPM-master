using Model.Dao;
using Model.EF;
using projCNPM.Areas.Admin.Models;
using projCNPM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projCNPM.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private OnlineSMSystemDB db = new OnlineSMSystemDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session[CommonConstant.ADMIN_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Login(LoginAdminModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.LoginAdmin(model.UserName, model.PassWord);
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var AdminSession = new UserLogin();
                    AdminSession.UserName = user.UserName;
                    AdminSession.UserId = user.MemberID;
                    AdminSession.Name = user.FirstName +" " + user.LastName;
                    Session.Add(CommonConstant.ADMIN_SESSION, AdminSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng");
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không thành công ");
            }
            return View("Index");
        }

    }
}