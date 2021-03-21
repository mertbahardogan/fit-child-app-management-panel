using FitChildPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitChildPanel.Controllers
{
    [Authorize]
    public class EgzersizController : Controller
    {
        DBFITCHILDEntities db = new DBFITCHILDEntities();
        // GET: Egzersiz
        public ActionResult Index()
        {
            var egzersizler = db.TBLEGZERSIZ.ToList();
            return View(egzersizler);
        }

        public ActionResult IslemGetir(int id)
        {
            var gelenVeri = db.TBLEGZERSIZ.Find(id);
            return View("IslemGetir", gelenVeri);
        }

        public ActionResult IslemGuncelle(TBLEGZERSIZ gelenEgzersiz)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("egzersizData", " güncelleme başarısız. Model geçersiz.");
                return View("IslemGetir");
            }
            db.Entry(gelenEgzersiz).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData.Add("egzersizData", " başarıyla güncellendi. ID: " + gelenEgzersiz.ID);
            return RedirectToAction("Index");
        }

        public ActionResult IslemSil(int id)
        {

            var gelenVeri = db.TBLEGZERSIZ.Find(id);
            db.TBLEGZERSIZ.Remove(gelenVeri);
            db.SaveChanges();
            TempData.Add("egzersizData", " başarıyla silindi. ID: " + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IslemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IslemEkle(TBLEGZERSIZ eklenecekEgzersiz)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("ekleData", " ekleme başarısız. Model geçersiz.");
                return View("IslemEkle");
            }
            db.TBLEGZERSIZ.Add(eklenecekEgzersiz);
            db.SaveChanges();
            TempData.Add("ekleData"," başarıyla eklendi. ID: "+ eklenecekEgzersiz.ID);
            return View("IslemEkle");
        }
    }
}