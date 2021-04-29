using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.d1 = c.Carilers.Count().ToString();
            ViewBag.d2 = c.Uruns.Count().ToString();
            ViewBag.d3 = c.Personels.Count().ToString();
            ViewBag.d4 = c.Kategoris.Count().ToString();
            ViewBag.d5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d8 = c.Uruns.OrderByDescending(x => x.SatisFiyatı).FirstOrDefault().UrunAd;
            ViewBag.d9 = c.Uruns.OrderBy(x => x.SatisFiyatı).FirstOrDefault().UrunAd;
            ViewBag.d10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d11 = c.Uruns.Count(x => x.Kategoriid == 1).ToString();
            ViewBag.d12 = c.Uruns.Count(x => x.Kategoriid == 3).ToString();
            ViewBag.d13 = c.Uruns.Where(u => u.UrunID == (c.SatisHarakets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();


            ViewBag.d14 = c.SatisHarakets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d15 = c.SatisHarakets.Count(x => x.SatisTarihi.Day == DateTime.Today.Day).ToString();

            try
            {
                ViewBag.d16 = c.SatisHarakets.Where(x => x.SatisTarihi.Day == DateTime.Today.Day).Sum(y => y.ToplamTutar).ToString();
            }
            catch (Exception ex)
            {
                ViewBag.d16 = "Satış yok";

            }

            return View();
        }
        public ActionResult KolayTablolar()
        {
            ViewBag.kategoriIsim = c.Kategoris.ToList();

            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Toplam = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult PartialDepartman()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd
                         into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Toplam = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }


        public PartialViewResult PartialSatis()
        {
            var degerler = c.SatisHarakets.OrderByDescending(t => t.SatisTarihi).Take(10).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialUrun()
        {
            var degerler = c.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialMarka()
        {

            var sorgu3 = from x in c.Uruns
                         group x by x.Marka
                         into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Toplam = g.Count()
                         };
            return PartialView(sorgu3.ToList());

        }



    }
}