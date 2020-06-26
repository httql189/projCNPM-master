using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projCNPM.Controllers
{
    public class ProductController : Controller
    {
        OnlineSMSystemDB db = new OnlineSMSystemDB();
        // GET: Product

        public ActionResult Index(int? size, int? page, string searchString)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "9", Value = "9" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            items.Add(new SelectListItem { Text = "200", Value = "200" });

            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            // 1.2. Tạo các biến ViewBag
            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.Products
                         where l.Status == true
                         select l);

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            var count = db.Products.Count();
            int pageSize = (size ?? count);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            //var linksS = from l in db.Products
            //select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.ProductName.Contains(searchString));
            }
            links = links.OrderBy(x => x.ProductID);
            return View(links.ToPagedList(1, 30));
        }
    }
}