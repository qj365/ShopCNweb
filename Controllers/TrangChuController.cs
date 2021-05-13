using ShopCNweb.Dao;
using ShopCNweb.Models.Entities;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ShopCNweb.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int pageNum = 1, int pageSize = 3, string name = "", int minp = 0, int maxp = int.MaxValue, int idcategory = 0)
        {
            ProductsDAO dao = new ProductsDAO();
            CategoryDAO daoC = new CategoryDAO();
            ViewData["cate"] = daoC.ListCate();
            if (minp > maxp)
                (minp, maxp) = (maxp, minp);
            return View(dao.listProducts(pageNum, pageSize, name, minp, maxp, idcategory));
        }

        public ActionResult Create()
        {
            CategoryDAO dao = new CategoryDAO();
            return View(dao.ListCate());
        }

        public ActionResult Edit(int id)
        {
            CategoryDAO dao = new CategoryDAO();
            ProductsDAO proDao = new ProductsDAO();
            ViewBag.cat = dao.ListCate();
            ViewBag.pro = proDao.getById(id);
            return View();
        }
        public ActionResult Delete(int id)
        {
            ProductsDAO dao = new ProductsDAO();
            dao.Delete(id);
            return Redirect("~/TrangChu/List");
        }

        [HttpPost]
        public ActionResult Create(string name, string price, string amount, string description, HttpPostedFileBase photo, string idcategory)
        {
            var img = Path.GetFileName(photo.FileName);
            CategoryDAO dao = new CategoryDAO();
            Products product = new Products();
            product.NAME = name;
            product.PRICE = int.Parse(price);
            product.AMOUNT = int.Parse(amount);
            product.DESCRIPTION = description;
            product.IDCATEGORY = int.Parse(idcategory);

            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/img/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    product.PHOTO = photo.FileName;
                    ProductsDAO daoP = new ProductsDAO();
                    daoP.Add(product);
                }
                return RedirectToAction("List");
            }
            else
            {
                return View(product);
            }


        }
        [HttpPost]
        public ActionResult Edit(int id, string name, string price, string amount, string description, HttpPostedFileBase photo, string idcategory)
        {

            ProductsDAO dao = new ProductsDAO();
            Products product = dao.getById(id);
            product.NAME = name;
            product.PRICE = int.Parse(price);
            product.AMOUNT = int.Parse(amount);
            product.DESCRIPTION = description;
            product.IDCATEGORY = int.Parse(idcategory);
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/img/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    product.PHOTO = photo.FileName;

                }
                dao.Edit(product);
                return RedirectToAction("List");
            }
            else
            {
                return View(product);
            }
        }
    }
}