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
    }
}