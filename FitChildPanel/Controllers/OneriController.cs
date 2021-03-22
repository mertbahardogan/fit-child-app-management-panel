using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitChildPanel.Controllers
{
    [Authorize]
    public class OneriController : Controller
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        // GET: Oneri
        public ActionResult Index()
        {
            var oneriler = db.TBLONERI.ToList();
            return View(oneriler);
        }

        public ActionResult IslemGetir(int id)
        {
            var gelenVeri = db.TBLONERI.Find(id);
            return View("IslemGetir", gelenVeri);
        }

        public ActionResult IslemGuncelle(TBLONERI gelenOneri)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("oneriData", " güncelleme başarısız. Model geçersiz.");
                return View("IslemGetir");
            }
            gelenOneri.OneriEklenmeTarih = DateTime.Now;
            db.Entry(gelenOneri).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData.Add("oneriData", " başarıyla güncellendi. ID: " + gelenOneri.ID);
            return RedirectToAction("Index");
        }

        public ActionResult IslemSil(int id)
        {

            var gelenVeri = db.TBLONERI.Find(id);
            db.TBLONERI.Remove(gelenVeri);
            db.SaveChanges();
            TempData.Add("oneriData", " başarıyla silindi. ID: " + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IslemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IslemEkle(TBLONERI eklenecekOneri)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("ekleOneriData", " ekleme başarısız. Model geçersiz.");
                return View("IslemEkle");
            }

            db.TBLONERI.Add(eklenecekOneri);
            eklenecekOneri.OneriEklenmeTarih = DateTime.Now;
            db.SaveChanges();
            TempData.Add("ekleOneriData", " başarıyla eklendi. ID: " + eklenecekOneri.ID);
            return View("IslemEkle");
        }
    }
}

