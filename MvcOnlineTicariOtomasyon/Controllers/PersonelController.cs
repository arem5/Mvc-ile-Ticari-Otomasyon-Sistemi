using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            ViewBag.dgr1 = ForDownBox();
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                GorselEkle(p);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.dgr1 = ForDownBox();
                return View("PersonelEkle");
            }
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            ViewBag.dgr1 = ForDownBox();
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                GorselEkle(p);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.dgr1 = ForDownBox();
                return View("PersonelGetir");
            }
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            prsn.PersonelPhone = p.PersonelPhone;
            prsn.PersonelEmail = p.PersonelEmail;
            prsn.PersonelMahalle = p.PersonelMahalle;
            prsn.PersonelSokak = p.PersonelSokak;
            prsn.PersonelApartmanKapiNo = p.PersonelApartmanKapiNo;
            prsn.PersonelSemtSehir = p.PersonelSemtSehir;
            prsn.Durum = p.Durum;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<SelectListItem> ForDownBox()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd, //Dropdownda ki veri
                                               Value = x.DepartmanID.ToString()  //Arka plandaki değer
                                           }).ToList();
            return deger1;
        }

        private void GorselEkle(Personel p)
        {
            string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            string yol = "~/Image/" + dosyaAdi + uzanti;
            Request.Files[0].SaveAs(Server.MapPath(yol));
            p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti;
        }
    }
}