using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            ViewBag.Musteri = c.Carilers.Count().ToString();
            ViewBag.Urunler = c.Uruns.Count().ToString();
            ViewBag.Personel = c.Personels.Count().ToString();
            ViewBag.Kategori = c.Kategoris.Count().ToString();

            var yapilacaklar = c.Yapilacaks.ToList();            
            return View(yapilacaklar);
        }

        

    }
}