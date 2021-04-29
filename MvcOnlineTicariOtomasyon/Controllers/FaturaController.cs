using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            f.FaturaTarih = DateTime.Parse(DateTime.Now.ToString());
            f.FaturaSaat = DateTime.Now.ToShortTimeString();
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.FaturaSaat = DateTime.Now.ToShortTimeString();
            fatura.FaturaTarih = DateTime.Parse(DateTime.Now.ToString());
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var ftrSeri = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo).FirstOrDefault(); //Departman adnı tablo üstüne yazabilmek için.
            ViewBag.seri = ftrSeri;

            var ftrSıra = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSıraNo).FirstOrDefault(); //Departman adnı tablo üstüne yazabilmek için.
            ViewBag.sıra = ftrSıra;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunAd
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}