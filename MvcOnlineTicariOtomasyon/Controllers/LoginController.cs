using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialCariKayit()
        {
            return PartialView();
        }       
        [HttpPost]
        public PartialViewResult PartialCariKayit(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariGiris(Cariler cari)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre && cari.CariSifre != null );
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}