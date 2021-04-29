using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var degerler = c.Uruns.Where(x => x.UrunID == id).FirstOrDefault();
            ViewBag.UcTaksit = Taksitlendir(degerler, 3);
            ViewBag.AltiTaksit = Taksitlendir(degerler, 6);
            ViewBag.DokuzTaksit = Taksitlendir(degerler, 9);           
            ViewBag.OnikiTaksit = Taksitlendir(degerler, 12);

            return View(degerler);
        }

        private decimal Taksitlendir(Urun degerler,int t)
        {
            return decimal.Round((degerler.SatisFiyatı / t), 2, MidpointRounding.AwayFromZero);

        }
    }
}