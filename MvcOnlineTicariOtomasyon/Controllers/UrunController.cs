using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult Yeniurun()
        {
            ViewBag.dgr1 = ForDownBox();
            return View();
        }
        [HttpPost]
        public ActionResult Yeniurun(Urun p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr1 = ForDownBox();
                return View("Yeniurun");
            }
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //Ürün silmek yerine durumu false yaparız ve yalnız true olan değerleri indexte gösteririz
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            ViewBag.dgr1 = ForDownBox();
            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr1 = ForDownBox();
                return View("UrunGetir");
            }
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyatı = p.AlisFiyatı;
            urn.Durum = p.Durum;
            urn.SatisFiyatı = p.SatisFiyatı;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

        private List<SelectListItem> ForDownBox()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd, //Dropdownda ki veri
                                               Value = x.KategoriID.ToString()  //Arka plandaki değer
                                           }).ToList();         
            return deger1;
        }
    }
}