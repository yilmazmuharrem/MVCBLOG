using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.onaylanmis = db.Makales.Where(i => i.Onay == true).Count();
            ViewBag.onaylanmamis = db.Makales.Where(i => i.Onay == false).Count();
            ViewBag.sayi = db.Makales.Count();
            return View();
        }
        public ActionResult YazarListesi()
        {
            var makale = db.Makales.ToList();
            return View(makale);
        }
        public ActionResult OnayListesi()
        {
            var makale = db.Makales.Where(i => i.Onay == true).ToList();
            return View(makale);
        }
        public ActionResult OnaysizListesi()
        {
            var makale = db.Makales.Where(i => i.Onay == false).ToList();
            return View(makale);
        }
    }
}