using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarakets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1, deger2, deger3;
            UrunCariPersonel(out deger1, out deger2, out deger3);

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket s)
        {
            s.SatisTarihi=DateTime.Parse(DateTime.Now.ToString());
            c.SatisHarakets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1, deger2, deger3;
            UrunCariPersonel(out deger1, out deger2, out deger3);

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = c.SatisHarakets.Find(id);
            deger.SatisTarihi = DateTime.Parse(DateTime.Now.ToString());
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHaraket p)
        {
            var deger = c.SatisHarakets.Find(p.SatisID);
            deger.Cariid = p.Cariid;
            deger.SatisAdet = p.SatisAdet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.SatisTarihi= DateTime.Parse(DateTime.Now.ToString());
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarakets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }

        private void UrunCariPersonel(out List<SelectListItem> deger1, out List<SelectListItem> deger2, out List<SelectListItem> deger3)
        {
            deger1 = (from x in c.Uruns.ToList()
                      select new SelectListItem
                      {
                          Text = x.UrunAd + " / " + x.Marka + "  --  Kalan Stok : " + x.Stok + "  --  Fiyat : " + x.SatisFiyatı,
                          Value = x.UrunID.ToString()
                      }).ToList();
            deger2 = (from x in c.Carilers.ToList()
                      select new SelectListItem
                      {
                          Text = x.CariAd + " " + x.CariSoyad,
                          Value = x.CariID.ToString()
                      }).ToList();
            deger3 = (from x in c.Personels.ToList()
                      where x.Durum == true
                      select new SelectListItem
                      {
                          Text = x.PersonelAd + " " + x.PersonelSoyad,
                          Value = x.PersonelID.ToString()
                      }).ToList();
        }
    }
}