using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class LoginUserController : Controller
    {
        DBVilaStoreEntities database = new DBVilaStoreEntities();
        // GET: LoginUser 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(AdminUser _user)
        {
            var check = database.AdminUsers.Where(s => s.ID == _user.ID && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
                if (check != null)
            {
                ViewBag.ErroInfo = "SaiInfo";
                return View("Index");
            }
                else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = _user.ID;
                Session["PasswordUser"] = _user.PasswordUser;
                return RedirectToAction("Index", "Product");
            }    
        }
    }
}
