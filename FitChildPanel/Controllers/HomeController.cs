using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitChildPanel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        public ActionResult Index()
        {
            ViewBag.Title ="Ana Sayfa";

            if (Session["kullaniciAdi"] == null)
            {
                if (Request.Cookies.AllKeys.Contains("USER_ID"))
                {
                    var kullanici = Request.Cookies["USER_ID"].Value;
                    var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KullaniciAdi == kullanici);
                    if (bilgiler != null)
                    {
                        Session["kullaniciAdi"] = bilgiler.KullaniciAdi;
                    }
                }
                else
                {
                    return RedirectToAction("GirisYap", "AdminLogin");
                }
            }


            return View();
        }
    }
}
