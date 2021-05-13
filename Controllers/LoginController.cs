using ShopCNweb.Dao;
using ShopCNweb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCNweb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session["username"] = null;
            return Redirect("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult loginAction(string username, string password)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            bool c = dao.Login(username, password);
            if (c)
            {
                Session["username"] = username;
                return RedirectToAction("Index", "Trangchu");
            }
            else
            {
                return View("Login");
            }
        }
        
    }
}