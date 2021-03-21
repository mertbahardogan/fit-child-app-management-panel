using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitChildPanel.Controllers
{
    public class AdminController : Controller
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        // GET: Admin
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLADMIN adminBilgileri)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KullaniciAdi == adminBilgileri.KullaniciAdi && x.Parola == adminBilgileri.Parola);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Response.Cookies["USER_ID"].Value = bilgiler.KullaniciAdi;
                Response.Cookies["USER_ID"].Expires = DateTime.Now.AddDays(1);
                Session["kullaniciAdi"] = bilgiler.KullaniciAdi;
                Session["resim"] = bilgiler.KullaniciResim;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("girisKontrol", "Kullanıcı Adı veya Parola yanlış.");
                return View();
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["USER_ID"].Expires = DateTime.Now.AddDays(-1);
            TempData.Add("girisKontrol", "Başarıyla çıkış yapıldı.");
            return RedirectToAction("GirisYap");
        }
    }
}