using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayi=1)
        {
            var makale = db.Makales.Where(i => i.Onay == true).Select(i=>new MakaleModel()
            {
                Id=i.Id,
                Baslik=i.Baslik,
                KullaniciAd=i.KullaniciAd,
                Resim=i.Resim,
                YayinTarih=i.YayinTarih,
                Onay=i.Onay,
                Goruntulenme=i.Goruntulenme,
                yorum=i.yorum,
                Aciklama=i.Aciklama.Length>60?i.Aciklama.Substring(0,60)+("[...]"):i.Aciklama
            }).ToList().ToPagedList(sayi,3);
            return View(makale);
        }
        public ActionResult MakaleListesi(int ? id)
        {
            var makale = db.Makales.Where(i => i.Onay == true).AsQueryable();
            if (id!=null)
            {
                makale = makale.Where(i => i.KategoriId == id);
            }
            return View(makale.ToList());
        }

        public ActionResult Ara(string deger)
        {
            var ara = db.Makales.Where(i => i.Onay == true && i.Aciklama.Contains(deger)).ToList();
            return View(ara);
        }
        public PartialViewResult EnCokOkunan()
        {
            var encok = db.Makales.Where(i => i.Onay == true).OrderByDescending(i => i.Goruntulenme).Take(5).ToList();
            return PartialView(encok);
        }
        public ActionResult Detay(int id)
        {
            var sonuc = (from ortalama in db.Yorums
                         where ortalama.MakaleId == id
                         select ortalama.Puan).DefaultIfEmpty(0).Average();

            ViewBag.ortalama = Math.Round(sonuc);

            var makale = db.Makales.Find(id);
            ViewBag.makale = makale;

            var sayi = db.Makales.ToList().Find(x => x.Id == id);
            sayi.Goruntulenme += 1;
            db.SaveChanges();

            ViewBag.sayi = db.Yorums.ToList().Where(i => i.MakaleId == id).Count();

            var yorum = new Yorum()
            {
                MakaleId=makale.Id
            };
            return View("Detay",yorum);
        }
        public ActionResult YorumGonder(Yorum yorum ,int rating)
        {
            yorum.KullaniciId = User.Identity.Name;
            yorum.Tarih = DateTime.Now;
            yorum.Puan = Convert.ToInt32(rating);
            db.Yorums.Add(yorum);
            db.SaveChanges();
            return RedirectToAction("Detay","Home",new { id=yorum.MakaleId});
        }
    }
}