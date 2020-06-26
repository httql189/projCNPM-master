using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Common;
using Model.Dao;
using Model.EF;
using projCNPM.Models;
using projCNPM.Common;

namespace projCNPM.Controllers
{
    public class UserController : Controller
    {
        private OnlineSMSystemDB db = new OnlineSMSystemDB();

        static string MaNgauNhien_SoChu(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(36);
                if (temp != -1 && temp == t)
                {
                    return MaNgauNhien_SoChu(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckValidUser(string userid, string password)
        {
            string result = "Fail";
            var userSession = new UserLogin();
            var data = from c in db.Members where c.UserName == userid && c.PassWord == password && c.GroupID == "MEMBER" && c.Status == true select c;
            if (data.Count() > 0)
            {
                userSession.UserName = userid;
                
                Session.Add(CommonConstant.USER_SESSION, userSession);
                result = "Success";

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveData(LoginModel model)
        {
            
            //string result = "Fail";
            if (ModelState.IsValid)
            {
                var userController = new UserDao();
                if (userController.CheckUserName(model.Username))
                {
                    return Json("Tên tài khoản đã tồn tại", JsonRequestBehavior.AllowGet);
                }
                else if (userController.CheckUserEmail(model.Email))
                {
                    return Json("Email đã tồn tại", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    
                    var user = new Member();
                    
                    user.UserName = model.Username;
                    user.PassWord = model.Password;
                    user.Email = model.Email;
                    user.Status = false;
                    user.VerifyCode = MaNgauNhien_SoChu(7);
                    var result = userController.ThemUser(user.UserName, user.PassWord, user.Email, user.Status, user.VerifyCode);
                    //var result = true;
                    string body = "Chào " + user.UserName + ",\n" +
                    "Cảm ơn bạn đã đăng ký! " +
                     "Vui lòng xác nhận email đăng ký \n" +
                    "Mã xác nhận: " + user.VerifyCode;
                    try
                    {
                        //new MailHelper().Send(body, user.Email, "Mã xác nhận từ SSFOOD");
                    }
                    catch
                    {

                    }
                    if (result)
                    {
                        return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
                    }        
                }
            }
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConfirmCode(string username, string verifycode)
        {
            string result = "Fail";
            LoginModel model = new LoginModel();
            var userController = new UserDao();       
            var user = new Member();
            user.VerifyCode = verifycode;
            var data = (from c in db.Members where c.VerifyCode == verifycode && c.UserName == username select c);
            //userController.updateVerifyCode(user.UserName, user.VerifyCode);
            if (data.Count() > 0)
            {
                result = "Success";
                userController.kiemTraMXN(username, true);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Đăng xuất
        public ActionResult LogOut()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return RedirectToAction("Index", "HomeUser");
        }

    }
}