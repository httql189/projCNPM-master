using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Controllers
{
    public class HomeUserController : Controller
    {
        private OnlineSMSystemDB db = new OnlineSMSystemDB();
        public ActionResult Index()
        {
            var product = db.Products.ToList();
            var links = (from l in db.Products
                         where l.Status == true
                         select l).ToList();
            return View();
        }
    }
}