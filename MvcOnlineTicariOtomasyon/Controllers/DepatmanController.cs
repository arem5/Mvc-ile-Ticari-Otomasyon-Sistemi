using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepatmanController : Controller
    {
        Context c = new Context();
        // GET: Depatman
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanEkle");
            }
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id); // id deki tm satırı tutar
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id); // id deki tm satırı tutar

            return View("DepartmanGetir", dep);
        }

        public ActionResult DepartmanGüncelle(Departman d)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanGetir");
            }
            var dep = c.Departmans.Find(d.DepartmanID);   //sayfadaki ıd alındı
            dep.DepartmanAd = d.DepartmanAd; //Yeni Değeri atarız
            dep.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault(); //Departman adnı tablo üstüne yazabilmek için.
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarakets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + "  " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }


    }
}