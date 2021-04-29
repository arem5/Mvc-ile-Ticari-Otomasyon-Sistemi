using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();  //Contex sınıfında tablolarımız var, bizi sql e bağlayan yer
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]   //Form Yüklendiğinde burası çalışır boş sayfa döner
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]   //Eğer bir butana tıklanırsa nurası çalışır
        public ActionResult KategoriEkle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            c.Kategoris.Add(k); //Contexteki kategorisin içine view'dan göndereceğimiz içerik olarak ekle
            c.SaveChanges();
            return RedirectToAction("Index");   //Index aksiyonuna yönlendir bizi
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id); // id deki tm satırı tutar
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);

        }
        public ActionResult KategoriGüncelle(Kategori k)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGetir");
            }
            var ktg = c.Kategoris.Find(k.KategoriID);   //sayfadaki ıd alındı
            ktg.KategoriAd = k.KategoriAd; //Yeni Değeri atarız
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}