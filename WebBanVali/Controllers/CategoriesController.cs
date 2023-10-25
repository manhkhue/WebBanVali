using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVali.Models;


namespace WebBanVali.Controllers
{
    public class CategoriesController : Controller
    {
        DBVilaStoreEntities database = new DBVilaStoreEntities();
        // GET: Categories
        public ActionResult Index()
        {
            return View(database.Categories.ToList());
        }
        public ActionResult Create(Category cate)
        {
            try
            {
                database.Categories.Add(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error create new");
            }
        }
    }
}